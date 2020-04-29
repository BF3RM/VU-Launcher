using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.Models.Entities.Common
{
	public abstract class ParamsPresetEntity : PresetEntity
	{
		public List<ParameterSelection> ParameterSelections = new List<ParameterSelection>();
	}
}
