using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Models.Entities.Extensions
{
    public static class ParamsPresetExtensions
    {
        public static TPresetItem ToItem<TPresetEntity, TPresetItem>(this TPresetEntity entity)
            where TPresetEntity : ParamsPresetEntity
            where TPresetItem : ParamsPresetItem, new()
        {
            var item = new TPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            item.ParameterSelections.AddRange(entity.ParameterSelections.ToItemList());
            item.IsDirty = false;

            return item;
        }

        public static TPresetEntity ToEntity<TPresetEntity, TPresetItem>(this TPresetItem item)
            where TPresetEntity : ParamsPresetEntity, new()
            where TPresetItem : ParamsPresetItem
        {
            var entity = new TPresetEntity()
            {
                Id = item.Id,
                Name = item.Name,
            };

            entity.ParameterSelections.AddRange(item.ParameterSelections.ToEntityList());

            return entity;
        }

        public static List<TPresetItem> ToItemList<TPresetEntity, TPresetItem>(this IEnumerable<TPresetEntity> entities)
            where TPresetEntity : ParamsPresetEntity
            where TPresetItem : ParamsPresetItem, new()
        {
            return entities.Select(e => e.ToItem<TPresetEntity, TPresetItem>()).ToList();
        }

        public static List<TPresetEntity> ToEntityList<TPresetEntity, TPresetItem>(this IEnumerable<TPresetItem> items)
            where TPresetEntity : ParamsPresetEntity, new()
            where TPresetItem : ParamsPresetItem
        {
            return items.Select(e => e.ToEntity<TPresetEntity, TPresetItem>()).ToList();
        }
    }
}
