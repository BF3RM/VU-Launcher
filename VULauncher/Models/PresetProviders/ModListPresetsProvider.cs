using System;
using System.Collections.Generic;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ModListPresetsProvider : FileRepository
    {
        private static readonly Lazy<ModListPresetsProvider> _lazy = new Lazy<ModListPresetsProvider>(() => new ModListPresetsProvider());
        public static ModListPresetsProvider Instance => _lazy.Value;

        public List<ModListPresetItem> ModListPresets = new List<ModListPresetItem>();

        private ModListPresetsProvider()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var modListPreset = new ModListPresetItem()
            {
                Name = "_", // this never shows
            };

            var modSelectionItem = new ModSelectionItem()
            {
                DisplayName = "testmod",
                IsChecked = true,
                IsDirty = false,
            };

            // TODO: Join existing mods with modselection list and put the result in the ModList collection

            modListPreset.ModSelection.Add(modSelectionItem);
            ModListPresets.Add(modListPreset);
        }
    }
}
