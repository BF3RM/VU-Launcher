using VULauncher.Models.PresetProviders;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ServerPresetsViewModel : PresetTabViewModel<ServerPresetItem, ServerPresetsProvider>
    {
        public override string TabHeaderName => "Server Presets";
        protected override string NewPresetExampleName => "My_Server_Preset";

        public ServerParamsViewModel ServerParamsViewModel { get; set; }
        public MapListsViewModel MapListsViewModel { get; set; }
        public StartupsViewModel StartupsViewModel { get; set; }
        public BanListsViewModel BanListsViewModel { get; set; }

        public ServerPresetsViewModel(ServerParamsViewModel serverParamsViewModel, MapListsViewModel mapListsViewModel, StartupsViewModel startupsViewModel, BanListsViewModel banListsViewModel)
            : base(ServerPresetsProvider.Instance)
        {
            ServerParamsViewModel = serverParamsViewModel;
            MapListsViewModel = mapListsViewModel;
            StartupsViewModel = startupsViewModel;
            BanListsViewModel = banListsViewModel;

            ServerParamsViewModel.PresetItemDeleted += ServerParamsViewModel_PresetItemDeleted;
            MapListsViewModel.PresetItemDeleted += MapListsViewModel_PresetItemDeleted;
            StartupsViewModel.PresetItemDeleted += StartupsViewModel_PresetItemDeleted;
            BanListsViewModel.PresetItemDeleted += BanListsViewModel_PresetItemDeleted;
        }

        private void ServerParamsViewModel_PresetItemDeleted(object sender, PresetItemDeletedEventArgs e)
        {
            foreach (var presetItem in Presets)
            {
                if (presetItem.ServerParamsPreset?.Id == e.DeletedPresetId)
                    presetItem.ServerParamsPreset = null;
            }
        }

        private void MapListsViewModel_PresetItemDeleted(object sender, PresetItemDeletedEventArgs e)
        {
            foreach (var presetItem in Presets)
            {
                if (presetItem.MapListPreset?.Id == e.DeletedPresetId)
                    presetItem.MapListPreset = null;
            }
        }

        private void StartupsViewModel_PresetItemDeleted(object sender, PresetItemDeletedEventArgs e)
        {
            foreach (var presetItem in Presets)
            {
                if (presetItem.StartupPreset?.Id == e.DeletedPresetId)
                    presetItem.StartupPreset = null;
            }
        }

        private void BanListsViewModel_PresetItemDeleted(object sender, PresetItemDeletedEventArgs e)
        {
            foreach (var presetItem in Presets)
            {
                if (presetItem.BanListPreset?.Id == e.DeletedPresetId)
                    presetItem.BanListPreset = null;
            }
        }
    }
}
