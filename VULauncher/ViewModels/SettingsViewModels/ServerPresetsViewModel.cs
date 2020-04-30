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

            RegisterChildItemCollection(Presets);
        }
    }
}
