using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Models.Repositories.Static;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class ServerParamsPresetExtensions
	{
        public static ServerParamsPresetItem ToItem(this ServerParamsPreset entity)
        {
            var item = new ServerParamsPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            item.ParameterSelections.AddRange(entity.ParameterSelections.ToItemList());

            // TODO: the selected parameters are a selection of existing (hardcoded parameters). find a way to implement this 
            //item.Parameters.AddRange(entity.Parameters.ToItemList());
            item.IsDirty = false;

            return item;
        }

        public static ServerParamsPreset ToEntity(this ServerParamsPresetItem item)
        {
            var entity = new ServerParamsPreset()
            {
                Id = item.Id,
                Name = item.Name,
            };

            entity.ParameterSelections.AddRange(item.ParameterSelections.ToEntityList());

            return entity;
        }

        public static List<ServerParamsPresetItem> ToItemList(this IEnumerable<ServerParamsPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ServerParamsPreset> ToEntityList(this IEnumerable<ServerParamsPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
