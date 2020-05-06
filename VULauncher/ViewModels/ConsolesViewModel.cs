using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows;
using VULauncher.Commands;
using VULauncher.Models.Config;
using VULauncher.Util;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.ConsoleViewModels;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels
{
    public class ConsolesViewModel : ViewModel
    {
	    private const string _vuPath = @"C:\Program Files (x86)\VeniceUnleashed\";
	    private static readonly string _vuExe = "vu.exe";
	    private static readonly string _vuCom = "vu.com";
	    private static readonly string _vuClient = "Client";
	    private static readonly string _vuServer = "Server";

        public ObservableCollection<DockableDocumentViewModel> DockingViewModels { get; set; } = new ObservableCollection<DockableDocumentViewModel>();

        private VuConsoleViewModel _activeConsoleViewModel;

        public VuConsoleViewModel ActiveConsoleViewModel
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

        private enum StartupType
        {
            Client = 0,
            Server = 1
        }

        private void Start(StartupType startupType, string presetName, string arguments, bool attach = false)
        {
            string environmentName = (startupType == StartupType.Client) ? _vuClient : _vuServer;
            string appName = (startupType == StartupType.Client) ? _vuExe : _vuCom;

            var vuConsoleViewModel = new VuConsoleViewModel($"{environmentName} - {presetName}");

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
                        MessageBoxResult result = MessageBox.Show($"Are you sure you want to close '{presetName}'?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
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
            }

            try
            {
                using (vuConsoleViewModel.GameProcess.Start(Configuration.VUInstallationDirectory, Path.Combine(Configuration.VUInstallationDirectory, appName), arguments))
                {
                    if (attach)
                    {
                        StreamReader streamReader = vuConsoleViewModel.GameProcess.ReadData();
                        while (vuConsoleViewModel.GameProcess.IsAlive() && !streamReader.EndOfStream)
                        {
                            string output = streamReader.ReadLine();

                            if (output != string.Empty)
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    vuConsoleViewModel.WriteLog(output);
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
                    vuConsoleViewModel.WriteLog("The following exception was raised: ");
                    vuConsoleViewModel.WriteLog(e.Message);
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
                    vuConsoleViewModel.WriteLog("Process is closed!");
                }
                else
                {
                    // meybe show error
                }
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

        public void StartClient(ClientPresetItem clientPresetItem)
        {
            new Thread(() => Start(StartupType.Client, clientPresetItem.Name, "-console -vudebug -dwebui -vextdebug -debug -updateBranch dev -tracedc -headless", true)).Start();
        }

        public void StartServer(ServerPresetItem serverPresetItem)
        {
            new Thread(() => Start(StartupType.Server, serverPresetItem.Name, "-server -dedicated -vudebug -high120 -highResTerrain -tracedc -headless", true)).Start();
        }

    }
}
