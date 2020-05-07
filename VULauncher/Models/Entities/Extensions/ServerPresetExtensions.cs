using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Models.PresetProviders;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities.Extensions
{
	public static class ServerPresetExtensions
	{
        public static ServerPresetItem ToItem(this ServerPreset entity)
        {
            return new ServerPresetItem()
            {
                Id = entity.Id,
                Name = entity.Name,
                BanListPreset = BanListPresetsProvider.Instance.FindPresetItemById(entity.BanListPresetId),
                MapListPreset = MapListPresetsProvider.Instance.FindPresetItemById(entity.MapListPresetId),
                ModListPreset = ModListPresetsProvider.Instance.FindPresetItemById(entity.ModListPresetId),
                ServerParamsPreset = ServerParamsPresetsProvider.Instance.FindPresetItemById(entity.ServerParamsPresetId),
                StartupPreset = StartupPresetsProvider.Instance.FindPresetItemById(entity.StartupPresetId),
                OpenConsole = entity.OpenConsole,
                SendRuntimeErrorDumps = entity.SendRuntimeErrorDumps,
                IsDirty = false,
            };
        }

        public static ServerPreset ToEntity(this ServerPresetItem item)
        {
            return new ServerPreset()
            {
                Id = item.Id,
                Name = item.Name,
                BanListPresetId = item.BanListPreset.Id,
                MapListPresetId = item.MapListPreset.Id,
                ModListPresetId = item.ModListPreset.Id,
                ServerParamsPresetId = item.ServerParamsPreset.Id,
                StartupPresetId = item.StartupPreset.Id,
                OpenConsole = item.OpenConsole,
                SendRuntimeErrorDumps = item.SendRuntimeErrorDumps,
            };
        }

        public static List<ServerPresetItem> ToItemList(this IEnumerable<ServerPreset> entities)
        {
            return entities.Select(e => e.ToItem()).ToList();
        }

        public static List<ServerPreset> ToEntityList(this IEnumerable<ServerPresetItem> items)
        {
            return items.Select(e => e.ToEntity()).ToList();
        }
    }
}
