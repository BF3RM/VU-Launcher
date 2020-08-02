using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
    public static class BanListPresetExtensions
    {
        public static BanListPresetItem ToItem(this BanListPreset entity)
        {
            var item = new BanListPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
            };

            item.BannedPlayers.AddRange(entity.BannedPlayers.ToItemList());
            item.BannedPlayers.IsDirty = false;
            item.IsDirty = false;

            return item;
        }

        public static BanListPreset ToEntity(this BanListPresetItem item)
        {
            return new BanListPreset()
            {
                Id = item.Id,
                Name = item.Name,
                BannedPlayers = item.BannedPlayers.ToEntityList(),
            };
        }

        public static List<BanListPresetItem> ToItemList(this IEnumerable<BanListPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<BanListPreset> ToEntityList(this IEnumerable<BanListPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
