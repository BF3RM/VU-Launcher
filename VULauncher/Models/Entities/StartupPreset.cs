using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
	public class StartupPreset : PresetEntity
	{
		public string StartupFileContent { get; set; }
	}
}
