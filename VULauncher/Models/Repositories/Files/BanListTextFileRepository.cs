using System;
using System.Collections.Generic;
using System.IO;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.UserData
{
	public class BanListTextFileRepository : TextFileRepository
	{
		private static readonly Lazy<BanListTextFileRepository> _lazy = new Lazy<BanListTextFileRepository>(() => new BanListTextFileRepository());
		public static BanListTextFileRepository Instance => _lazy.Value;

        public BanListTextFileRepository()
            : base(Configuration.BanListFilePath)
        {
        }

		public void WriteBanListFile(IEnumerable<BannedPlayerItem> bannedPlayerItems)
		{
			string banList = string.Empty;

			foreach (var bannedPlayerItem in bannedPlayerItems)
			{
				banList += bannedPlayerItem.PlayerName;
				banList += Environment.NewLine;
			}

			OverwriteFile(banList);
		}
    }
}
