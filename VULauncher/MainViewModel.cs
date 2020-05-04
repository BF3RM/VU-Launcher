using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using VULauncher.Commands;
using VULauncher.Models.Config;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.Models.Setup;
using VULauncher.ViewModels;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher
{
    public class MainViewModel : ViewModel
    {
        private ActiveViewType _activeViewType;
        private ViewModel _currentViewModel;

        public ConsolesViewModel ConsolesViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }
        public ConfigViewModel ConfigViewModel { get; set; }

        public RelayCommand StartClientPresetCommand { get; }
        public RelayCommand SaveTabCommand { get; }
        public RelayCommand SaveAllTabsCommand { get; }

        public MainViewModel()
        {
            LocalSetup.VerifyOrCreate();

            ConsolesViewModel = new ConsolesViewModel();
            SettingsViewModel = new SettingsViewModel();
            ConfigViewModel = new ConfigViewModel();

            StartClientPresetCommand = new RelayCommand(x => StartClientPreset(), x => CanStartClientPreset);

            SaveTabCommand = new RelayCommand(x => SaveTab(), x => CanSaveTab);
            SaveAllTabsCommand = new RelayCommand(x => SaveAllTabs(), x => CanSaveTab);

            ActiveViewType = ActiveViewType.Console;
        }

        private void StartClientPreset()
        {
            //ConsolesViewModel?.StartClientPreset();
        }

        private void SaveTab()
        {
            SettingsViewModel.SaveTab();
        }

        private void SaveAllTabs()
        {
            SettingsViewModel.SaveAllTabs();
        }

        private bool CanSaveTab => CurrentViewModel == SettingsViewModel && SettingsViewModel.IsDirty;

        private bool CanStartClientPreset => ConsolesViewModel != null;

        public ActiveViewType ActiveViewType
        {
            get => _activeViewType;
            
            set
            {
                if (SetField(ref _activeViewType, value))
                {
                    CurrentViewModel = value switch
                    {
                        ActiveViewType.Console => ConsolesViewModel,
                        ActiveViewType.Settings => SettingsViewModel,
                        ActiveViewType.Config => ConfigViewModel,
                        _ => CurrentViewModel
                    };
                }
            } 
        }

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetField(ref _currentViewModel, value);
        }
    }
}
