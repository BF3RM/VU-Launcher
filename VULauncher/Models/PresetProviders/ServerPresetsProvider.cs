using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.Common;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.PresetProviders
{
	public class ServerPresetsProvider : PresetsProvider<ServerPreset, ServerPresetItem>
	{
		private static readonly Lazy<ServerPresetsProvider> _lazy = new Lazy<ServerPresetsProvider>(() => new ServerPresetsProvider());
		public static ServerPresetsProvider Instance => _lazy.Value;

		protected override string FileName => "ServerPresets";

		protected override IEnumerable<ServerPreset> ConvertItemsToEntities(IEnumerable<ServerPresetItem> presetItems)
		{
			return presetItems.ToEntityList();
		}

		protected override IEnumerable<ServerPresetItem> ConvertEntitiesToItems(IEnumerable<ServerPreset> presetEntities)
		{
			var modNamesExistingOnDrive = ModsRepository.Instance.Mods.Select(m => m.Name).ToList();

			foreach (var presetEntity in presetEntities)
			{
				var notFoundModNames = new List<string>();
				var newlyAddedModNames = new List<string>();

				foreach (var modSelection in presetEntity.ModSelections)
				{
					if (!modNamesExistingOnDrive.Any(modName => modName == modSelection.ModName))
					{
						notFoundModNames.Add(modSelection.ModName);
					}
				}

				var modSelectionNames = presetEntity.ModSelections.Select(m => m.ModName).ToList();

				foreach (var modName in modNamesExistingOnDrive)
				{
					if (!modSelectionNames.Contains(modName))
					{
						newlyAddedModNames.Add(modName);
					}
				}

				// Add unchecked modSelections for mods that have been added to the mods dir
				presetEntity.ModSelections.AddRange(newlyAddedModNames.Select(n => new ModSelection() {IsChecked = false, ModName = n}));

				// Remove existing ModSelections for mods that have been deleted from the mods dir
				presetEntity.ModSelections.RemoveAll(s => notFoundModNames.Contains(s.ModName));

				presetEntity.ModSelections = presetEntity.ModSelections.OrderBy(s => s.ModName).ToList();
			}

			return presetEntities.ToItemList();
		}

		protected override ServerPresetItem CreateNewPresetItem(ServerPresetItem newPresetItem)
		{
			newPresetItem.OpenConsole = true;
			newPresetItem.BanListPreset = BanListPresetsProvider.Instance.FindFirstPreset();
			newPresetItem.MapListPreset = MapListPresetsProvider.Instance.FindFirstPreset();
			newPresetItem.ServerParamsPreset = ServerParamsPresetsProvider.Instance.FindFirstPreset();
			newPresetItem.StartupPreset = StartupPresetsProvider.Instance.FindFirstPreset();
			newPresetItem.ModSelections.AddRange(GetNewModSelection());
			return newPresetItem;
		}

		private IEnumerable<ModSelectionItem> GetNewModSelection()
		{
			var modSelectionItems = ModsRepository.Instance.Mods.Select(m => new ModSelectionItem() {IsChecked = false, ModName = m.Name});
			return modSelectionItems;
		}
    }
}
