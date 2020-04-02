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
    public class ClientPresetsProvider : PresetsProvider<ClientPreset, ClientPresetItem>
    {
        private static readonly Lazy<ClientParamsPresetsProvider> _lazy = new Lazy<ClientParamsPresetsProvider>(() => new ClientParamsPresetsProvider());
        public static ClientParamsPresetsProvider Instance => _lazy.Value;

        protected override string SubDirectory => "ClientPresets";

        protected override IEnumerable<ClientPreset> ConvertItemsToEntities(IEnumerable<ClientPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<ClientPresetItem> ConvertEntitiesToItems(IEnumerable<ClientPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        public ClientPresetsProvider()
        {
            LoadDummyData();
        }

        private void LoadDummyData() //TODO: DUMMY
        {
            var clientPreset = new ClientPresetItem()
            {
                Name = "Client_60Hz",
                FrequencyType = FrequencyType._60Hz,
                OpenConsole = true,
                SendRuntimeErrorDumps = false,
                ClientParamsPreset = ClientParamsPresetsProvider.Instance.PresetItems.FirstOrDefault(),
                IsDirty = false,
            };

            PresetItems.Add(clientPreset);
        }
    }
}
