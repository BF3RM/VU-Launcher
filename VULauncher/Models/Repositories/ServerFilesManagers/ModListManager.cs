using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.ServerFilesManagers
{
	public class ModListManager : ServerFilesManager
	{
		private static readonly Lazy<ModListManager> _lazy = new Lazy<ModListManager>(() => new ModListManager());
		public static ModListManager Instance => _lazy.Value;

		public void WriteModListFile(IEnumerable<ModSelectionItem> modSelections)
		{
			string modList = string.Empty;

			foreach (var modSelection in modSelections)
			{
				if (modSelection.IsChecked)
				{
					modList += modSelection.ModName;
					modList += Environment.NewLine;
				}
				else
				{
					modList += $"#{modSelection.ModName}";
					modList += Environment.NewLine;
				}
			}

			File.WriteAllText(Configuration.ModListFilePath, modList);
		}
	}
}
