using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
    public static class BannedPlayerExtensions
    {
        public static BannedPlayerItem ToItem(this BannedPlayer entity)
        {
            return new BannedPlayerItem()
            {
                Id = entity.Id,
                BanDate = entity.BanDate,
                BanReason = entity.BanReason,
                Index = entity.Index,
                PlayerIp = entity.PlayerIp,
                PlayerName = entity.PlayerName,
                UnbanDate = entity.UnbanDate,
                IsDeleted = false,
                IsDirty = false,
            };
        }

        public static BannedPlayer ToEntity(this BannedPlayerItem item)
        {
            return new BannedPlayer()
            {
                Id = item.Id,
                BanReason = item.BanReason,
                Index = item.Index,
                UnbanDate = item.UnbanDate,
                BanDate = item.BanDate,
                PlayerName = item.PlayerName,
                PlayerIp = item.PlayerIp,
            };
        }

        public static List<BannedPlayerItem> ToItemList(this IEnumerable<BannedPlayer> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<BannedPlayer> ToEntityList(this IEnumerable<BannedPlayerItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
