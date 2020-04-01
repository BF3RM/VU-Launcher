using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    class ServerPresetsProvider : FileRepository
    {
        private static readonly Lazy<ServerPresetsProvider> _lazy = new Lazy<ServerPresetsProvider>(() => new ServerPresetsProvider());
        public static ServerPresetsProvider Instance => _lazy.Value;

        public List<ServerPresetItem> ServerPresets = new List<ServerPresetItem>();

        private ServerPresetsProvider()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var serverPresetItem = new ServerPresetItem()
            {
                Name = "Server_60Hz",
                FrequencyType = FrequencyType._60Hz,
                ModListPreset = ModListPresetsProvider.Instance.ModListPresets.FirstOrDefault(),
                ServerParamsPreset = ServerParamsPresetsProvider.Instance.ServerParamsPresets.FirstOrDefault(),
                MapListPreset = MapListPresetsProvider.Instance.MapListPresets.FirstOrDefault(),
                StartupPreset = StartupPresetsProvider.Instance.StartupPresets.FirstOrDefault(),
                BanListPreset = BanListPresetsProvider.Instance.PresetItems.FirstOrDefault(), 
                OpenConsole = true,
                SendRuntimeErrorDumps = false,
                IsDirty = false,
            };

            ServerPresets.Add(serverPresetItem);
        }
    }
}
