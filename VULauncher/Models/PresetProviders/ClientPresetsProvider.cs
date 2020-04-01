using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ClientPresetsProvider : FileRepository
    {
        private static readonly Lazy<ClientPresetsProvider> _lazy = new Lazy<ClientPresetsProvider>(() => new ClientPresetsProvider());
        public static ClientPresetsProvider Instance => _lazy.Value;

        public List<ClientPresetItem> ClientPresets = new List<ClientPresetItem>();

        private ClientPresetsProvider()
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
                ClientParamsPreset = ClientParamsPresetsProvider.Instance.ClientParamsPresets.FirstOrDefault(),
                IsDirty = false,
            };

            ClientPresets.Add(clientPreset);
        }
    }
}
