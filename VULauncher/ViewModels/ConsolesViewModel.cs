using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using VULauncher.Commands;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.ConsoleViewModels;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;
using VULauncher.ViewModels.Items.Extensions;

namespace VULauncher.ViewModels
{
    public class ConsolesViewModel : ViewModel
    {
        private static readonly string _vuExe = "vu.exe";
        private static readonly string _vuCom = "vu.com";
        private static readonly string _vuClient = "Client";
        private static readonly string _vuServer = "Server";
        private VuConsoleViewModel _activeConsoleViewModel;

        public ObservableRangeCollection<DockableDocumentViewModel> DockingViewModels { get; set; } = new ObservableRangeCollection<DockableDocumentViewModel>();

        public bool IsAnyRunning => IsClientRunning || IsServerRunning;
        public bool IsClientRunning => DockingViewModels.Any(d => (d as VuConsoleViewModel)?.StartupType == StartupType.Client);
        public bool IsServerRunning => DockingViewModels.Any(d => (d as VuConsoleViewModel)?.StartupType == StartupType.Server);

        public VuConsoleViewModel ActiveConsoleViewModel // TODO: not used. is this needed for any docking stuff?
        {
            get => _activeConsoleViewModel;
            set => SetField(ref _activeConsoleViewModel, value);
        }

        public void Add(VuConsoleViewModel vuConsoleViewModel)
        {
            if (vuConsoleViewModel != null)
            {
                DockingViewModels.Add(vuConsoleViewModel);
            }
        }

        public void Remove(VuConsoleViewModel vuConsoleViewModel)
        {
            if (vuConsoleViewModel != null)
            {
                DockingViewModels.Remove(vuConsoleViewModel);
            }
        }

        public void StartVuConsole(ILaunchPresetItem launchPresetItem, StartupType startupType)
        {
            if (launchPresetItem == null) throw new ArgumentNullException(nameof(launchPresetItem));

            var launchParameters = launchPresetItem.GetSelectedParameters().Select(l => l.ConcatStartupStrings()).ToArray();
            var openConsoleInsideLauncher = launchPresetItem.OpenConsole;

            if (startupType == StartupType.Server)
            {
                OverwriteTxtFiles((ServerPresetItem)launchPresetItem);
            }

            new Thread(() => CreateVuConsoleViewModelAndGameProcess(startupType, launchPresetItem.Name, launchParameters, openConsoleInsideLauncher)).Start();
        }

        private void OverwriteTxtFiles(ServerPresetItem serverPresetItem)
        {
            ModListTextFileRepository.Instance.WriteModListFile(serverPresetItem.ModSelections);
            MapListTextFileRepository.Instance.WriteMapListFile(serverPresetItem.MapListPreset.MapSelections);
            StartupTextFileRepository.Instance.WriteStartupFile(serverPresetItem.StartupPreset.StartupFileContent);
            BanListTextFileRepository.Instance.WriteBanListFile(serverPresetItem.BanListPreset.BannedPlayers);
        }

        private void CreateVuConsoleViewModelAndGameProcess(StartupType startupType, string presetName, string[] launchParameters, bool attach = false)
        {
            string environmentName = (startupType == StartupType.Client) ? _vuClient : _vuServer;
            string appName = (startupType == StartupType.Client) ? _vuExe : _vuCom;

            var vuConsoleViewModel = new VuConsoleViewModel($"{environmentName} - {presetName}", startupType);

            if (attach)
            {
                vuConsoleViewModel.CloseCommand = new RelayCommand(x =>
                {
                    if (vuConsoleViewModel.GameProcess != null && !vuConsoleViewModel.GameProcess.IsAlive())
                    {
                        Remove(vuConsoleViewModel);
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show($"Are you sure you want to close '{presetName}'? This will close the game process.", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

                        if (result == MessageBoxResult.Yes)
                        {
                            Kill(vuConsoleViewModel);
                        }
                    }
                });

                Application.Current.Dispatcher.Invoke(() =>
                {
                    Add(vuConsoleViewModel);
                });

                vuConsoleViewModel.IsSelected = true;
                ActiveConsoleViewModel = vuConsoleViewModel;
            }

            //Timer timer = new Timer((t) => { }, null, 0, 0);

            try
            {
                using (vuConsoleViewModel.GameProcess.Start(Configuration.VUInstallationDirectory, Path.Combine(Configuration.VUBinariesDirectory, appName), launchParameters))
                {
                    if (attach)
                    {
                        StreamReader streamReader = vuConsoleViewModel.GameProcess.ReadData();
                        ConcurrentDictionary<int, string> logList = new ConcurrentDictionary<int, string>();
                        int id = 0;
                        int lastLog = 0;
                        Timer timer = new Timer((t) =>
                        {
                            foreach(var log in logList)
                            {
                                if (log.Key > lastLog)
                                {
                                    vuConsoleViewModel.WriteLine(log.Value);
                                }
                            }
                            if (logList.Count > 0)
                            {
                                lastLog = logList.Keys.Max();
                            }
                        }, null, 0, 3000);

                        while (vuConsoleViewModel.GameProcess.IsAlive() && !streamReader.EndOfStream)
                        {
                            string output = streamReader.ReadLine();

                            if (!string.IsNullOrWhiteSpace(output))
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    if (id > 5000) {
                                        logList.Clear();

                                        vuConsoleViewModel.TextBoxContent = "";
                                        vuConsoleViewModel.Dispose();

                                        id = 0;
                                    }

                                    logList.TryAdd(id, output);
                                    id++;
                                });
                            }
                        }
                        vuConsoleViewModel.GameProcess.Exception();
                    }
                }
            }
            catch (Exception e)
            {
                if (attach)
                {
                    vuConsoleViewModel.WriteLine($"--- The following exception was raised on the {environmentName}: ---");
                    vuConsoleViewModel.WriteLine(e.Message);
                }
                else
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            finally
            {
                if (attach)
                {
                    vuConsoleViewModel.WriteLine($"--- The Venice Unleashed {environmentName} process was closed from outside VULauncher ---");
                }
                else
                {
                    // meybe show error
                }
            }
        }

        private void WriteLogs(List<string> logList, VuConsoleViewModel vuConsoleViewModel)
        {
            foreach (var log in logList)
            {
                vuConsoleViewModel.WriteLine(log);
            }
        }

        public void Kill(VuConsoleViewModel vuConsoleViewModel)
        {
            if (vuConsoleViewModel != null)
            {
                Remove(vuConsoleViewModel);
                vuConsoleViewModel.GameProcess.Kill();
            }
        }

        public void CloseAllConsoles()
        {
            foreach (var viewModel in DockingViewModels)
            {
                ((VuConsoleViewModel)viewModel).GameProcess.Kill();
            }

            DockingViewModels.RemoveAll(d => true);
        }
    }
}
