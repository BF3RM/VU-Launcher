using System;
using System.Collections.Generic;
using System.IO;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.UserData
{
	public class ModListTextFileRepository : TextFileRepository
	{
		private static readonly Lazy<ModListTextFileRepository> _lazy = new Lazy<ModListTextFileRepository>(() => new ModListTextFileRepository());
		public static ModListTextFileRepository Instance => _lazy.Value;

		public ModListTextFileRepository() 
            : base(Configuration.ModListFilePath)
        {
        }

		public void WriteModListFile(IEnumerable<ModSelectionItem> modSelections)
		{
			string modList = string.Empty;

			modList += "# This file has been modified by VU Launcher";
			modList += Environment.NewLine;
            modList += Environment.NewLine;

			foreach (var modSelection in modSelections)
			{
				if (modSelection.IsChecked)
				{
					modList += modSelection.ModName;
					modList += Environment.NewLine;
				}
			}

            modList += Environment.NewLine;

			foreach (var modSelection in modSelections)
            {
                if (!modSelection.IsChecked)
                {
                    modList += $"#{modSelection.ModName}";
                    modList += Environment.NewLine;
                }
            }

			OverwriteFile(modList);
		}
    }
}
