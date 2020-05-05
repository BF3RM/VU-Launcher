using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using VULauncher.Commands;
using VULauncher.ViewModels;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.ConsoleViewModels;

namespace VULauncher.Modules
{
    public class Game : ViewModel
    {
        private const string _vuPath = @"C:\Program Files (x86)\VeniceUnleashed\";
        private static readonly string _vu = "VU";
        private static readonly string _vuExe = "vu.exe";
        private static readonly string _vuCom = "vu.com";
        private static readonly string _vuClient = "Client";
        private static readonly string _vuServer = "Server";
        public ConsolesViewModel ConsolesViewModel { get; set; }
        public VuConsoleViewModel consoleViewModel { get; set; }
        public ProcessUtils GameProcess { get; set; }

        enum MODE {
            CLIENT = 0,
            SERVER = 1
        };

        public Game(ConsolesViewModel _consolesViewModel)
        {
            if (_consolesViewModel == null)
            {
                ConsolesViewModel = new ConsolesViewModel();
            } 
            else
            {
                ConsolesViewModel = _consolesViewModel;
            }

            GameProcess = new ProcessUtils();
        }

        void Start(MODE mode, string presetName, string arguments, bool attach = false)
        {
            string modeName = (mode == MODE.CLIENT) ? _vuClient : _vuServer;
            string appName = (mode == MODE.CLIENT) ? _vuExe : _vuCom;
            if (attach)
            {
                consoleViewModel = new VuConsoleViewModel($"{_vu} {modeName} - {presetName}");
                consoleViewModel.CloseCommand = new RelayCommand(x =>
                {
                    if (GameProcess != null && !GameProcess.IsAlive())
                    {
                        ConsolesViewModel.Remove(consoleViewModel);
                    }
                    else
                    {
                        MessageBoxResult result = MessageBox.Show($"Are you sure you want to close '{presetName}'?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (result == MessageBoxResult.Yes)
                        {
                            Kill();
                        }
                    }
                });

                if (ConsolesViewModel != null)
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        ConsolesViewModel.Add(consoleViewModel);
                    });
                    consoleViewModel.IsSelected = true;
                }
            }

            try
            {
                using (GameProcess.Start(_vuPath, _vuPath + appName, arguments))
                {
                    if (attach)
                    {
                        StreamReader streamReader = GameProcess.ReadData();
                        while (GameProcess.IsAlive() && !streamReader.EndOfStream)
                        {
                            string output = streamReader.ReadLine();

                            if (output != string.Empty)
                            {
                                Application.Current.Dispatcher.Invoke(() =>
                                {
                                    consoleViewModel.WriteLog(output);
                                });
                            }
                        }

                        GameProcess.Exception();
                    }
                }
            }
            catch (Exception e)
            {
                if (attach)
                {
                    consoleViewModel.WriteLog("The following exception was raised: ");
                    consoleViewModel.WriteLog(e.Message);
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
                    consoleViewModel.WriteLog("Process is closed!");
                } 
                else
                {
                    // meybe show error
                }
            }
        }

        public void Kill()
        {
            if (consoleViewModel != null)
            {
                ConsolesViewModel.Remove(consoleViewModel);
            }
            GameProcess.Kill();
        }

        public void StartClientTest()
        {
            new Thread(() => Start(MODE.CLIENT, "Test 1", "-console -vudebug -dwebui -vextdebug -debug -updateBranch dev -tracedc -headless", true)).Start();
        }

        public void StartServerTest()
        {
            new Thread(() => Start(MODE.SERVER, "Test 2", "-server -dedicated -vudebug -high120 -highResTerrain -tracedc -headless", true)).Start();
        }

    }
}
