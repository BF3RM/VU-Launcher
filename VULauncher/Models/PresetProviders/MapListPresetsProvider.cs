using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Static;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Enums;
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

        protected override MapListPresetItem CreateNewPresetItem(MapListPresetItem newPresetItem)
        {
            var maplistTextFileLines = MapListTextFileRepository.Instance.FileContentLines;

            if (maplistTextFileLines.Any())
            {
                for (int i = 0; i < maplistTextFileLines.Length; i++)
                {
                    var parts = maplistTextFileLines[i].Split(" ");
                    var mapType = (MapType)Enum.Parse(typeof(MapType), parts[0]);
                    var gameModeType = (GameModeType)Enum.Parse(typeof(GameModeType), parts[1]);
                    var repeats = int.Parse(parts[2]);

                    newPresetItem.MapSelections.Add(new MapSelectionItem()
                    {
                        Index = i,
                        MapType = mapType,
                        GameModeType = gameModeType,
                        Repeats = repeats,
                    });
                }
            }

            return newPresetItem;
        }
    }
}
