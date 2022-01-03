using System;
using System.Collections.Generic;
using System.IO;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories.UserData
{
	public class MapListTextFileRepository : TextFileRepository
	{
		private static readonly Lazy<MapListTextFileRepository> _lazy = new Lazy<MapListTextFileRepository>(() => new MapListTextFileRepository());
		public static MapListTextFileRepository Instance => _lazy.Value;

        public MapListTextFileRepository()
            : base(Configuration.MapListFilePath)
        {
        }

		public void WriteMapListFile(IEnumerable<MapSelectionItem> mapSelections)
		{
			string mapList = string.Empty;

			foreach (var mapSelection in mapSelections)
			{
				if (!mapSelection.IsChecked)
					continue;
				
				mapList += $"{GetMapName(mapSelection.MapType.Value)} {GetGameModeName(mapSelection.GameModeType.Value)} {mapSelection.Repeats}";
				mapList += Environment.NewLine;
			}

			OverwriteFile(mapList);
		}

		private string GetMapName(MapType mapType)
		{
			return Enum.GetName(typeof(MapType), mapType);
		}

		private string GetGameModeName(GameModeType gameModeType)
		{
			return Enum.GetName(typeof(GameModeType), gameModeType);
		}
    }
}
