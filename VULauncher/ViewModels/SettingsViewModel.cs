using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;
using VULauncher.ViewModels.SettingsViewModels;

namespace VULauncher.ViewModels
{
    public class SettingsViewModel : ViewModel
    {
        private int _tabIndex;

        public ClientPresetsViewModel ClientPresetsViewModel { get; set; } = new ClientPresetsViewModel();
        public ServerPresetsViewModel ServerPresetsViewModel { get; set; } = new ServerPresetsViewModel();
        public ClientParamsViewModel ClientParamsViewModel { get; set; } = new ClientParamsViewModel();
        public ServerParamsViewModel ServerParamsViewModel { get; set; } = new ServerParamsViewModel();
        public MapListsViewModel MapListsViewModel { get; set; } = new MapListsViewModel();
        public StartupsViewModel StartupsViewModel { get; set; } = new StartupsViewModel();
        public BanListsViewModel BanListsViewModel { get; set; } = new BanListsViewModel();

        public List<ITabViewModel> TabViewModels { get; }

        public int TabIndex
        {
            get => _tabIndex;
            set => SetField(ref _tabIndex, value);
        }

        public SettingsViewModel()
        {
            TabViewModels = new List<ITabViewModel>()
            {
                ClientPresetsViewModel,
                ServerPresetsViewModel,
                ClientParamsViewModel,
                ServerParamsViewModel,
                MapListsViewModel,
                StartupsViewModel,
                BanListsViewModel,
            };

            foreach (var tabViewModel in TabViewModels)
            {
                tabViewModel.TabIndexChanged += TabViewModel_OnTabIndexChanged;
            }
        }

        private void TabViewModel_OnTabIndexChanged(object sender, TabIndexChangedEventArgs e)
        {
            TabIndex = e.NewTabIndex;
        }
    }
}
