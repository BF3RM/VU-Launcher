using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class StartupPresetExtensions
	{
        public static StartupPresetItem ToItem(this StartupPreset entity)
        {
            var item = new StartupPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
                StartupFileContent = entity.StartupFileContent,
                IsDirty = false
            };

            return item;
        }

        public static StartupPreset ToEntity(this StartupPresetItem item)
        {
            return new StartupPreset()
            {
                Id = item.Id,
                Name = item.Name,
                StartupFileContent = item.StartupFileContent,
            };
        }

        public static List<StartupPresetItem> ToItemList(this IEnumerable<StartupPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<StartupPreset> ToEntityList(this IEnumerable<StartupPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
