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

        protected override string SubDirectory => "ServerPresets";

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
                FrequencyType = FrequencyType._60Hz,
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
    }
}
