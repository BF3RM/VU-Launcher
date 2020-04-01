using System;
using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;
using VULauncher.Views.Dialogs;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ServerPresetsViewModel : PresetTabViewModel<ServerPresetItem>
    {
        public override string TabHeaderName { get; } = "Server Presets";
        //public WpfObservableRangeCollection<ServerParamsPresetItem> ServerParamsPresets { get; set; } = new WpfObservableRangeCollection<ServerParamsPresetItem>();
        //public WpfObservableRangeCollection<StartupPresetItem> StartupPresets { get; set; } = new WpfObservableRangeCollection<StartupPresetItem>();
        //public WpfObservableRangeCollection<MapListPresetItem> MapListPresets { get; set; } = new WpfObservableRangeCollection<MapListPresetItem>();
        //public WpfObservableRangeCollection<BanListPresetItem> BanListPresets { get; set; } = new WpfObservableRangeCollection<BanListPresetItem>();

        public ServerParamsViewModel ServerParamsViewModel { get; set; }
        public MapListsViewModel MapListsViewModel { get; set; }
        public StartupsViewModel StartupsViewModel { get; set; }
        public BanListsViewModel BanListsViewModel { get; set; }

        public ServerPresetsViewModel(ServerParamsViewModel serverParamsViewModel, MapListsViewModel mapListsViewModel, StartupsViewModel startupsViewModel, BanListsViewModel banListsViewModel)
        {
            Presets.AddRange(ServerPresetsProvider.Instance.ServerPresets);
            SelectedPreset = Presets.FirstOrDefault();

            ServerParamsViewModel = serverParamsViewModel;
            MapListsViewModel = mapListsViewModel;
            StartupsViewModel = startupsViewModel;
            BanListsViewModel = banListsViewModel;
        }
    }
}
