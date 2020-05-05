using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ServerPresetsProvider : PresetsProvider<ServerPreset, ServerPresetItem>
    {
        private static readonly Lazy<ServerPresetsProvider> _lazy = new Lazy<ServerPresetsProvider>(() => new ServerPresetsProvider());
        public static ServerPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "ServerPresets";

        protected override IEnumerable<ServerPreset> ConvertItemsToEntities(IEnumerable<ServerPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<ServerPresetItem> ConvertEntitiesToItems(IEnumerable<ServerPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        protected override void LoadDummyData() //TODO: DUMMY
        {
            var serverPresetItem = new ServerPreset()
            {
                Id = 1,
                Name = "Server_60Hz",
                ModListPresetId = 1,
                ServerParamsPresetId = 1,
                MapListPresetId = 1,
                StartupPresetId = 1,
                BanListPresetId = 1, 
                OpenConsole = true,
                SendRuntimeErrorDumps = false,
            };

            PresetEntities.Add(serverPresetItem);
        }

        protected override ServerPresetItem CreateEmptyPresetItem(ServerPresetItem newPresetItem)
        {
            newPresetItem.SendRuntimeErrorDumps = true;
            newPresetItem.OpenConsole = true;
            newPresetItem.BanListPreset = BanListPresetsProvider.Instance.FindPresetById(1).ToItem();
            newPresetItem.MapListPreset = MapListPresetsProvider.Instance.FindPresetById(1).ToItem();
            newPresetItem.ModListPreset = ModListPresetsProvider.Instance.CreateEmptyPresetItem(newPresetItem.Id, "_"); // TODO: giving it the same ID as parent, probably bad?
            newPresetItem.ServerParamsPreset = ServerParamsPresetsProvider.Instance.FindPresetById(1).ToItem();
            newPresetItem.StartupPreset = StartupPresetsProvider.Instance.FindPresetById(1).ToItem();
            return newPresetItem;
        }
    }
}
