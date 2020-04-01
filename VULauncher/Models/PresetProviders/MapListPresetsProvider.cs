using System;
using System.Collections.Generic;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class MapListPresetsProvider : FileRepository
    {
        private static readonly Lazy<MapListPresetsProvider> _lazy = new Lazy<MapListPresetsProvider>(() => new MapListPresetsProvider());
        public static MapListPresetsProvider Instance => _lazy.Value;

        public List<MapListPresetItem> MapListPresets = new List<MapListPresetItem>();

        private MapListPresetsProvider()
        {
            base.Initialize();
        }

        public override void Load() // TODO: DUMMY
        {
            var mapListPreset = new MapListPresetItem()
            {
                Name = "RM_MapList",
            };

            var maps = MapsRepository.Instance.Maps;

            var mapList = new List<MapToPlayItem>()
            {
                new MapToPlayItem()
                {
                    Index = 0,
                    MapType = maps[0].MapType,
                    GameModeType = maps[0].GameModeTypes[0],
                    Repeats = 1,
                    IsDirty = false,
                },

                new MapToPlayItem()
                {
                    Index = 1,
                    MapType = maps[1].MapType,
                    GameModeType = maps[1].GameModeTypes[1],
                    Repeats = 1,
                    IsDirty = false,
                }
            };

            mapListPreset.MapList.AddRange(mapList);
            mapListPreset.IsDirty = false;

            MapListPresets.Add(mapListPreset);
        }
    }
}
