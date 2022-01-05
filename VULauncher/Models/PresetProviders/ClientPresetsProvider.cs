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
        private static readonly Lazy<ClientPresetsProvider> _lazy = new Lazy<ClientPresetsProvider>(() => new ClientPresetsProvider());
        public static ClientPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "ClientPresets";

        protected override IEnumerable<ClientPreset> ConvertItemsToEntities(IEnumerable<ClientPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<ClientPresetItem> ConvertEntitiesToItems(IEnumerable<ClientPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        protected override ClientPresetItem CreateNewPresetItem(ClientPresetItem newPresetItem)
        {
            newPresetItem.OpenConsole = true;
            newPresetItem.ClientParamsPreset = ClientParamsPresetsProvider.Instance.FindFirstPreset();
            return newPresetItem;
        }
    }
}
