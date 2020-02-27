using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.Presets;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    class ServerPresetsRepository : FileRepository
    {
        private static readonly Lazy<ServerPresetsRepository> _lazy = new Lazy<ServerPresetsRepository>(() => new ServerPresetsRepository());
        public static ServerPresetsRepository Instance => _lazy.Value;

        public List<ServerPresetItem> ServerPresets = new List<ServerPresetItem>();

        private ServerPresetsRepository()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var serverPresetItem = new ServerPresetItem()
            {
                Name = "Server_60Hz",
                FrequencyType = FrequencyType._60Hz,
                ModListPreset = ModListPresetsRepository.Instance.ModListPresets.FirstOrDefault(),
                ServerParamsPreset = ServerParamsPresetsRepository.Instance.ServerParamsPresets.FirstOrDefault(),
                MapListPreset = MapListPresetsRepository.Instance.MapListPresets.FirstOrDefault(),
                StartupPreset = StartupPresetsRepository.Instance.StartupPresets.FirstOrDefault(),
                BanListPreset = BanListPresetsRepository.Instance.BanListPresets.FirstOrDefault(),
                OpenConsole = true,
                SendRuntimeErrorDumps = false,
                IsDirty = false,
            };

            ServerPresets.Add(serverPresetItem);
        }
    }
}
