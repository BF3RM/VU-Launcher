using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Entities
{
	public class MapSelection : SelectionEntity
	{
		public int Index { get; set; }
		public MapType MapType { get; set; }
		public GameModeType GameModeType { get; set; }
		public int Repeats { get; set; }
	}
}
