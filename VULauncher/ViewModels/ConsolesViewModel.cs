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
        public ObservableCollection<DockingViewModel> DockingViewModels { get; set; } = new ObservableCollection<DockingViewModel>();

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
            //var consoleViewModel3 = new VuConsoleViewModel("VU Client 3");
            //var consoleViewModel4 = new VuConsoleViewModel("VU Client 4");

            //DockingViewModels.Add(consoleViewModel);
            //DockingViewModels.Add(consoleViewModel2);
            //DockingViewModels.Add(consoleViewModel3);
            //DockingViewModels.Add(consoleViewModel4);
        }

        public void StartClientPreset(string presetName)
        {
            var consoleViewModel = new VuConsoleViewModel($"VU Client - {presetName}");
            DockingViewModels.Add(consoleViewModel);

        }
    }
}
