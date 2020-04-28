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

        protected override string SubDirectory => "MapListPresets";

        protected override IEnumerable<MapListPreset> ConvertItemsToEntities(IEnumerable<MapListPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<MapListPresetItem> ConvertEntitiesToItems(IEnumerable<MapListPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        protected override void LoadDummyData() // TODO: DUMMY
        {
            var mapListPreset = new MapListPreset()
            {
                Id = 1,
                Name = "RM_MapList",
            };

            var maps = MapsRepository.Instance.Maps;

            var mapList = new List<MapSelection>()
            {
                new MapSelection()
                {
                    Index = 0,
                    MapType = maps[0].MapType,
                    GameModeType = maps[0].GameModeTypes[0],
                    Repeats = 1,
                },

                new MapSelection()
                {
                    Index = 1,
                    MapType = maps[1].MapType,
                    GameModeType = maps[1].GameModeTypes[1],
                    Repeats = 1,
                }
            };

            mapListPreset.MapSelections.AddRange(mapList);

            PresetEntities.Add(mapListPreset);
        }
    }
}
