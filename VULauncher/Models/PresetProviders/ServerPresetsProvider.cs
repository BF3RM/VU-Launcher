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
            newPresetItem.BanListPreset = BanListPresetsProvider.Instance.FindPresetItemById(1);
            newPresetItem.MapListPreset = MapListPresetsProvider.Instance.FindPresetItemById(1);
            newPresetItem.ModListPreset = ModListPresetsProvider.Instance.CreateEmptyPresetItem("_");
            newPresetItem.ServerParamsPreset = ServerParamsPresetsProvider.Instance.FindPresetItemById(1);
            newPresetItem.StartupPreset = StartupPresetsProvider.Instance.FindPresetItemById(1);
            return newPresetItem;
        }

        //protected override void SaveDependenciesOfPresetItems(List<ServerPresetItem> presetItems)
        //{
        //    BanListPresetsProvider.Instance.AddAndSave(presetItems.Select(p => p.BanListPreset));
        //    MapListPresetsProvider.Instance.AddAndSave(presetItems.Select(p => p.MapListPreset));
        //    ModListPresetsProvider.Instance.AddAndSave(presetItems.Select(p => p.ModListPreset));
        //    ServerParamsPresetsProvider.Instance.AddAndSave(presetItems.Select(p => p.ServerParamsPreset));
        //    StartupPresetsProvider.Instance.AddAndSave(presetItems.Select(p => p.StartupPreset));
        //}
    }
}
