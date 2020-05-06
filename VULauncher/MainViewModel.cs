using System.Collections.Generic;
using VULauncher.Commands;
using VULauncher.Models.Setup;
using VULauncher.Modules;
using VULauncher.ViewModels;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;

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
        public RelayCommand StartServerPresetCommand { get; }
       
        public RelayCommand SaveTabCommand { get; }
        public RelayCommand SaveAllTabsCommand { get; }
        public RelayCommand DiscardChangesTabCommand { get; }
        public RelayCommand DiscardChangesAllTabsCommand { get; }

        public List<Game> GameList { get; set; }

        public MainViewModel()
        {
            LocalSetup.VerifyOrCreate();

            ConsolesViewModel = new ConsolesViewModel();
            SettingsViewModel = new SettingsViewModel();
            ConfigViewModel = new ConfigViewModel();

            SaveTabCommand = new RelayCommand(x => SaveTab(), x => CanSaveTab);
            SaveAllTabsCommand = new RelayCommand(x => SaveAllTabs(), x => CanSaveTab);
            DiscardChangesTabCommand = new RelayCommand(x => DiscardChangesTab(), x => CanDiscardChangesTab);
            DiscardChangesAllTabsCommand = new RelayCommand(x => DiscardChangesAllTabs(), x => CanDiscardChangesTab);

            StartClientPresetCommand = new RelayCommand(x => StartClientPreset(), x => CanStartClientPreset);
            StartServerPresetCommand = new RelayCommand(x => StartServerPreset(), x => CanStartServerPreset);

            GameList = new List<Game>();

            ActiveViewType = ActiveViewType.Console;
        }

        private void StartClientPreset()
        {
            Game game = new Game(ConsolesViewModel);
            game.StartClientTest();
            GameList.Add(game);
        }

        private void StartServerPreset()
        {
            Game game = new Game(ConsolesViewModel);
            game.StartServerTest();
            GameList.Add(game);
        }

        private void SaveTab()
        {
            SettingsViewModel.SaveTab();
        }

        private void SaveAllTabs()
        {
            SettingsViewModel.SaveAllTabs();
        }

        private void DiscardChangesTab()
        {
            SettingsViewModel.DiscardChangesTab();
        }

        private void DiscardChangesAllTabs()
        {
            SettingsViewModel.DiscardChangesAllTabs();
        }

        private bool CanSaveTab => CurrentViewModel == SettingsViewModel && SettingsViewModel.IsDirty;
        private bool CanDiscardChangesTab => CurrentViewModel == SettingsViewModel && SettingsViewModel.IsDirty;

        private bool CanStartClientPreset => ConsolesViewModel != null;
        private bool CanStartServerPreset => ConsolesViewModel != null;

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
