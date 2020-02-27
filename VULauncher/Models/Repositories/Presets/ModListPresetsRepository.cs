using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.Presets
{
    public class ModListPresetsRepository : FileRepository
    {
        private static readonly Lazy<ModListPresetsRepository> _lazy = new Lazy<ModListPresetsRepository>(() => new ModListPresetsRepository());
        public static ModListPresetsRepository Instance => _lazy.Value;

        public List<ModListPresetItem> ModListPresets = new List<ModListPresetItem>();

        private ModListPresetsRepository()
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
