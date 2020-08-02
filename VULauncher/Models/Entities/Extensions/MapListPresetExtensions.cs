using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
    public static class MapListPresetExtensions
    {
        public static MapListPresetItem ToItem(this MapListPreset entity)
        {
            var item = new MapListPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            item.MapSelections.AddRange(entity.MapSelections.ToItemList());
            item.MapSelections.IsDirty = false;

            // TODO: the selected parameters are a selection of existing (hardcoded parameters). find a way to implement this 
            //item.Parameters.AddRange(entity.Parameters.ToItemList());
            item.IsDirty = false;

            return item;
        }

        public static MapListPreset ToEntity(this MapListPresetItem item)
        {
            return new MapListPreset()
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public static List<MapListPresetItem> ToItemList(this IEnumerable<MapListPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<MapListPreset> ToEntityList(this IEnumerable<MapListPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
