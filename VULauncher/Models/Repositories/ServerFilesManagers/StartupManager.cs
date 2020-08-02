using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.ServerFilesManagers
{
	public class StartupManager : ServerFilesManager
	{
		private static readonly Lazy<StartupManager> _lazy = new Lazy<StartupManager>(() => new StartupManager());
		public static StartupManager Instance => _lazy.Value;

		public void WriteStartupFile(string startupFileContent)
		{
			File.WriteAllText(Configuration.StartupFilePath, startupFileContent);
		}
	}
}
