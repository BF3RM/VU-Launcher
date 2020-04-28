using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class MapListsViewModel : PresetTabViewModel<MapListPresetItem, MapListPresetsProvider>
    {
        public override string TabHeaderName { get; } = "MapLists";
        public MapListsViewModel()
            : base(MapListPresetsProvider.Instance)
        {
            RegisterChildItemCollection(Presets);
        }
    }
}
