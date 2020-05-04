using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class MapListsViewModel : PresetTabViewModel<MapListPresetItem, MapListPresetsProvider>
    {
        public override string TabHeaderName => "MapLists";
        protected override string NewPresetExampleName => "My_Map_List";

        public MapListsViewModel()
            : base(MapListPresetsProvider.Instance)
        {
        }
    }
}
