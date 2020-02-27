using System;
using System.Linq;
using VULauncher.Models.Repositories;
using VULauncher.Models.Repositories.Presets;
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
        public WpfObservableRangeCollection<ServerParamsPresetItem> ServerParamsPresets { get; set; } = new WpfObservableRangeCollection<ServerParamsPresetItem>();
        public WpfObservableRangeCollection<StartupPresetItem> StartupPresets { get; set; } = new WpfObservableRangeCollection<StartupPresetItem>();
        public WpfObservableRangeCollection<MapListPresetItem> MapListPresets { get; set; } = new WpfObservableRangeCollection<MapListPresetItem>();
        public WpfObservableRangeCollection<BanListPresetItem> BanListPresets { get; set; } = new WpfObservableRangeCollection<BanListPresetItem>();

        public ServerPresetsViewModel()
        {
            Presets.AddRange(ServerPresetsRepository.Instance.ServerPresets);
            SelectedPreset = Presets.FirstOrDefault();
            ServerParamsPresets.AddRange(ServerParamsPresetsRepository.Instance.ServerParamsPresets);
            StartupPresets.AddRange(StartupPresetsRepository.Instance.StartupPresets);
            MapListPresets.AddRange(MapListPresetsRepository.Instance.MapListPresets);
            BanListPresets.AddRange(BanListPresetsRepository.Instance.BanListPresets);
        }
    }
}
