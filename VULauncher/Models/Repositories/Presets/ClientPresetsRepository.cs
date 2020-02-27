using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class ClientPresetsRepository : FileRepository
    {
        private static readonly Lazy<ClientPresetsRepository> _lazy = new Lazy<ClientPresetsRepository>(() => new ClientPresetsRepository());
        public static ClientPresetsRepository Instance => _lazy.Value;

        public List<ClientPresetItem> ClientPresets = new List<ClientPresetItem>();

        private ClientPresetsRepository()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var clientPreset = new ClientPresetItem()
            {
                Name = "Client_60Hz",
                FrequencyType = FrequencyType._60Hz,
                OpenConsole = true,
                SendRuntimeErrorDumps = false,
                ClientParamsPreset = ClientParamsPresetsRepository.Instance.ClientParamsPresets.FirstOrDefault(),
                IsDirty = false,
            };

            ClientPresets.Add(clientPreset);
        }
    }
}
