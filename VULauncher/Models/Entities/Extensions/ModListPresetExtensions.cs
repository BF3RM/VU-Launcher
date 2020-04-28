using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class ModListPresetExtensions
	{
        public static ModListPresetItem ToItem(this ModListPreset entity)
        {
            var item = new ModListPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            item.ModSelections.AddRange(entity.ModSelections.ToItemList());

            // TODO: the selected parameters are a selection of existing (hardcoded parameters). find a way to implement this 
            //item.Parameters.AddRange(entity.Parameters.ToItemList());
            item.IsDirty = false;

            return item;
        }

        public static ModListPreset ToEntity(this ModListPresetItem item)
        {
            return new ModListPreset()
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public static List<ModListPresetItem> ToItemList(this IEnumerable<ModListPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ModListPreset> ToEntityList(this IEnumerable<ModListPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
