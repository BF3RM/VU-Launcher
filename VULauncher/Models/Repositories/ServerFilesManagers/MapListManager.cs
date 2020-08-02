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
	public class MapListManager : ServerFilesManager
	{
		private static readonly Lazy<MapListManager> _lazy = new Lazy<MapListManager>(() => new MapListManager());
		public static MapListManager Instance => _lazy.Value;

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

			File.WriteAllText(Configuration.MapListFilePath, mapList);
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
