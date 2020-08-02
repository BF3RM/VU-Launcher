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
	public class BanListManager : ServerFilesManager
	{
		private static readonly Lazy<BanListManager> _lazy = new Lazy<BanListManager>(() => new BanListManager());
		public static BanListManager Instance => _lazy.Value;

		public void WriteBanListFile(IEnumerable<BannedPlayerItem> bannedPlayerItems)
		{
			string banList = string.Empty;

			foreach (var bannedPlayerItem in bannedPlayerItems)
			{
				banList += bannedPlayerItem.PlayerName;
				banList += Environment.NewLine;
			}

			File.WriteAllText(Configuration.BanListFilePath, banList);
		}
	}
}
