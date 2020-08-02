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

            item.ParameterSelections.AddRange(entity.ParameterSelections.ToItemList());
            item.ParameterSelections.IsDirty = false;
            item.IsDirty = false;

            return item;
        }

        public static ClientParamsPreset ToEntity(this ClientParamsPresetItem item)
        {
            var entity = new ClientParamsPreset()
            {
                Id = item.Id,
                Name = item.Name,
            };

            entity.ParameterSelections.AddRange(item.ParameterSelections.ToEntityList());

            return entity;
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
