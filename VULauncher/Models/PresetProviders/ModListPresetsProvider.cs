using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
    public class ModListPresetsProvider : PresetsProvider<ModListPreset, ModListPresetItem>
    {
        private static readonly Lazy<ModListPresetsProvider> _lazy = new Lazy<ModListPresetsProvider>(() => new ModListPresetsProvider());
        public static ModListPresetsProvider Instance => _lazy.Value;

        protected override string SubDirectory => "ModListPresets";

        protected override IEnumerable<ModListPreset> ConvertItemsToEntities(IEnumerable<ModListPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<ModListPresetItem> ConvertEntitiesToItems(IEnumerable<ModListPreset> presetEntities)
        {
            var modNamesExistingOnDrive = ModsRepository.Instance.Mods.Select(m => m.Name);

            foreach (var presetEntity in presetEntities)
            {
                var notFoundModNames = new List<string>();
                var notFoundModSelectionsNames = new List<string>();

                foreach (var modSelection in presetEntity.ModSelections)
                {
                    if (!modNamesExistingOnDrive.Any(modName => modName == modSelection.ModName))
                    {
                        notFoundModNames.Add(modSelection.ModName);
                    }
                }

                var modSelectionNames = presetEntity.ModSelections.Select(m => m.ModName);

                foreach (var modName in modNamesExistingOnDrive)
                {
                    if (!modSelectionNames.Contains(modName))
                    {
                        notFoundModSelectionsNames.Add(modName);
                    }
                }

                // Add unchecked modSelections for mods that have been added to the mods dir
                presetEntity.ModSelections.AddRange(notFoundModSelectionsNames.Select(n => new ModSelection() { IsChecked = false, ModName = n }));

                // Remove existing ModSelections for mods that have been deleted from the mods dir
                presetEntity.ModSelections.RemoveAll(s => notFoundModNames.Contains(s.ModName));

                presetEntity.ModSelections = presetEntity.ModSelections.OrderBy(s => s.ModName).ToList();
            }

            return presetEntities.ToItemList();
        }

        protected override void LoadDummyData() //TODO: DUMMY
        {
            var modListPreset = new ModListPreset()
            {
                Id = 1,
                Name = "_", // this never shows
            };

            var modSelection = new ModSelection()
            {
                ModName = "RealityMod",
                IsChecked = true,
            };

            // TODO: Join existing mods with modselection list and put the result in the ModList collection

            modListPreset.ModSelections.Add(modSelection);
            PresetEntities.Add(modListPreset);
        }
    }
}
