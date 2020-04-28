using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class MapSelectionExtensions
	{
        public static MapSelectionItem ToItem(this MapSelection entity)
        {
            var item = new MapSelectionItem()
            {
                Id = entity.Id,
                Index = entity.Index,
                IsChecked = entity.IsChecked,
                GameModeType = entity.GameModeType,
                MapType = entity.MapType,
                Repeats = entity.Repeats,
                IsDirty = false
            };


            return item;
        }

        public static MapSelection ToEntity(this MapSelectionItem item)
        {
            return new MapSelection()
            {
                Id = item.Id,
                Index = item.Index,
                IsChecked = item.IsChecked,
                GameModeType = item.GameModeType.HasValue ? item.GameModeType.Value : throw new InvalidOperationException("GameModeType has to be defined"), // TODO: ugly, handle invalid values in frontend
                MapType = item.MapType.HasValue ? item.MapType.Value : throw new InvalidOperationException("MapType has to be defined"),
                Repeats = item.Repeats,
            };
        }

        public static List<MapSelectionItem> ToItemList(this IEnumerable<MapSelection> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<MapSelection> ToEntityList(this IEnumerable<MapSelectionItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
