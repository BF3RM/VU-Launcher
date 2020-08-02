using System;
using System.Collections.Generic;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class MapListPresetsProvider : PresetsProvider<MapListPreset, MapListPresetItem>
    {
        private static readonly Lazy<MapListPresetsProvider> _lazy = new Lazy<MapListPresetsProvider>(() => new MapListPresetsProvider());
        public static MapListPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "MapListPresets";

        protected override IEnumerable<MapListPreset> ConvertItemsToEntities(IEnumerable<MapListPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<MapListPresetItem> ConvertEntitiesToItems(IEnumerable<MapListPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }
    }
}
