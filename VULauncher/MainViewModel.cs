using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Commands;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
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
        private ClientPresetItem _selectedClientPreset;
        private ServerPresetItem _selectedServerPreset;
        private ViewModel _currentViewModel;

        public ConsolesViewModel ConsolesViewModel { get; set; }
        public SettingsViewModel SettingsViewModel { get; set; }

        public RelayCommand StartClientPresetCommand { get; }
        public RelayCommand SaveTabCommand { get; }
        public RelayCommand SaveAllTabsCommand { get; }

        public ObservableItemCollection<ClientPresetItem> ClientPresets { get; set; } = new ObservableItemCollection<ClientPresetItem>();
        public ClientPresetItem SelectedClientPreset
        {
            get => _selectedClientPreset;
            set => SetField(ref _selectedClientPreset, value);
        }

        public ObservableItemCollection<ServerPresetItem> ServerPresets { get; set; } = new ObservableItemCollection<ServerPresetItem>();
        public ServerPresetItem SelectedServerPreset
        {
            get => _selectedServerPreset;
            set => SetField(ref _selectedServerPreset, value);
        }

        public MainViewModel()
        {
            ConsolesViewModel = new ConsolesViewModel();
            SettingsViewModel = new SettingsViewModel();

            StartClientPresetCommand = new RelayCommand(x => StartClientPreset(), x => CanStartClientPreset);

            SaveTabCommand = new RelayCommand(x => SaveTab(), x => CanSaveTab);
            SaveAllTabsCommand = new RelayCommand(x => SaveAllTabs(), x => CanSaveTab);

            ClientPresets.AddRange(ClientPresetsProvider.Instance.PresetItems);
            SelectedClientPreset = ClientPresets.FirstOrDefault();

            ServerPresets.AddRange(ServerPresetsProvider.Instance.PresetItems);
            SelectedServerPreset = ServerPresets.FirstOrDefault();

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
                    CurrentViewModel = value == ActiveViewType.Console
                        ? (ViewModel) ConsolesViewModel
                        : SettingsViewModel;
                }
            } 
        }

        public ViewModel CurrentViewModel
        {
            get => _currentViewModel;
            set => SetField(ref _currentViewModel, value);
        }

        //public ClientPresetsViewModel ClientPresetsViewModel { get; set; } = new ClientPresetsViewModel();
        //public ServerPresetsViewModel ServerPresetsViewModel { get; set; } = new ServerPresetsViewModel();
        //public ClientParamsViewModel ClientParamsViewModel { get; set; } = new ClientParamsViewModel();
        //public ServerParamsViewModel ServerParamsViewModel { get; set; } = new ServerParamsViewModel();
        //public MapListsViewModel MapListsViewModel { get; set; } = new MapListsViewModel();
        //public StartupsViewModel StartupsViewModel { get; set; } = new StartupsViewModel();
        //public BanListsViewModel BanListsViewModel { get; set; } = new BanListsViewModel();

        //public List<PresetTabViewModel> TabViewModels { get; }

        //private int _tabIndex;
        //public int TabIndex
        //{
        //    get => _tabIndex;
        //    set => SetField(ref _tabIndex, value);
        //}

        //public MainViewModel()
        //{
        //    TabViewModels = new List<PresetTabViewModel>()
        //    {
        //        ClientPresetsViewModel,
        //        ServerPresetsViewModel,
        //        ClientParamsViewModel,
        //        ServerParamsViewModel,
        //        MapListsViewModel,
        //        StartupsViewModel,
        //        BanListsViewModel,
        //    };

        //    foreach (var tabViewModel in TabViewModels)
        //    {
        //        tabViewModel.TabIndexChanged += TabViewModel_OnTabIndexChanged;
        //    }
        //}

        //private void TabViewModel_OnTabIndexChanged(object sender, TabIndexChangedEventArgs e)
        //{
        //    TabIndex = e.NewTabIndex;
        //}
    }
}
