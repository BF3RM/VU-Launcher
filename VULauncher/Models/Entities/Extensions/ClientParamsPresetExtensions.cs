using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
    public static class ClientParamsPresetExtensions
    {
        public static ClientParamsPresetItem ToItem(this ClientParamsPreset entity)
        {
            var item = new ClientParamsPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            // TODO: the selected parameters are a selection of existing (hardcoded parameters). find a way to implement this 
            //item.Parameters.AddRange(entity.Parameters.ToItemList());
            item.IsDirty = false;

            return item;
        }

        public static ClientParamsPreset ToEntity(this ClientParamsPresetItem item)
        {
            return new ClientParamsPreset()
            {
                Id = item.Id,
                Name = item.Name,
                //Parameters = item.Parameters.ToEntityList(),
            };
        }

        public static List<ClientParamsPresetItem> ToItemList(this IEnumerable<ClientParamsPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ClientParamsPreset> ToEntityList(this IEnumerable<ClientParamsPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
