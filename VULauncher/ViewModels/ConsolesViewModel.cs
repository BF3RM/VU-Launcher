using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.ConsoleViewModels;

namespace VULauncher.ViewModels
{
    public class ConsolesViewModel : ViewModel
    {
        public ObservableCollection<DockableDocumentViewModel> DockingViewModels { get; set; } = new ObservableCollection<DockableDocumentViewModel>();

        private VuConsoleViewModel _activeConsoleViewModel;

        public VuConsoleViewModel ActiveConsoleViewModel
        {
            get => _activeConsoleViewModel;
            set => SetField(ref _activeConsoleViewModel, value);
        }

        public ConsolesViewModel()
        {
            //var consoleViewModel = new VuConsoleViewModel("VU Client 1");
            //var consoleViewModel2 = new VuConsoleViewModel("VU Client 2");
            ////var consoleViewModel3 = new VuConsoleViewModel("VU Client 3");
            ////var consoleViewModel4 = new VuConsoleViewModel("VU Client 4");
            //DockingViewModels.Add(consoleViewModel);
            //DockingViewModels.Add(consoleViewModel2);
            //consoleViewModel.WriteLog("hello yeeeee");
            //consoleViewModel2.WriteLog("hello yeeeee 22222");
            //DockingViewModels.Add(consoleViewModel3);
            //DockingViewModels.Add(consoleViewModel4);
        }

        public void Add(VuConsoleViewModel consoleViewModel)
        {
            if (consoleViewModel != null)
            {
                DockingViewModels.Add(consoleViewModel);
            }
        }

        public void Remove(VuConsoleViewModel consoleViewModel)
        {
            if (consoleViewModel != null)
            {
                DockingViewModels.Remove(consoleViewModel);
            }
        }

        public void StartClientPreset(string presetName)
        {
            var consoleViewModel = new VuConsoleViewModel($"VU Client - {presetName}");
            DockingViewModels.Add(consoleViewModel);
            for (int i = 0; i < 80; i++)
            {
                consoleViewModel.WriteLog($"hello yeeeee {i}");
            }

            consoleViewModel.IsSelected = true;
        }
    }
}
