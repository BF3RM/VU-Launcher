using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class ModSelectionExtensions
	{
        public static ModSelectionItem ToItem(this ModSelection entity)
        {
            var item = new ModSelectionItem()
            {
                Id = entity.Id,
                ModName = entity.ModName,
                IsChecked = entity.IsChecked,
                IsDirty = false
            };


            return item;
        }

        public static ModSelection ToEntity(this ModSelectionItem item)
        {
            return new ModSelection()
            {
                Id = item.Id,
                ModName = item.ModName,
                IsChecked = item.IsChecked,
            };
        }

        public static List<ModSelectionItem> ToItemList(this IEnumerable<ModSelection> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ModSelection> ToEntityList(this IEnumerable<ModSelectionItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
