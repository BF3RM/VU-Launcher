using System;
using System.Collections.Generic;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class StartupPresetsProvider : PresetsProvider<StartupPreset, StartupPresetItem>
    {
        private static readonly Lazy<StartupPresetsProvider> _lazy = new Lazy<StartupPresetsProvider>(() => new StartupPresetsProvider());
        public static StartupPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "Startups";

        protected override IEnumerable<StartupPreset> ConvertItemsToEntities(IEnumerable<StartupPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<StartupPresetItem> ConvertEntitiesToItems(IEnumerable<StartupPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        protected override StartupPresetItem CreateNewPresetItem(StartupPresetItem newPresetItem)
        {
            var existingStartupFileContent = StartupTextFileRepository.Instance.FileContent;
            var defaultStartupFileContent = StartupTextFileRepository.Instance.DefaultStartupContent;

            newPresetItem.StartupFileContent = !string.IsNullOrEmpty(existingStartupFileContent)
                ? existingStartupFileContent
                : defaultStartupFileContent;

            return newPresetItem;
        }
    }
}
