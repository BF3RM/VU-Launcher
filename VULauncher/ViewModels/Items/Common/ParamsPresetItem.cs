using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;

namespace VULauncher.ViewModels.Items.Common
{
	public class ParamsPresetItem : PresetItem
	{
		public ObservableItemCollection<ParameterSelectionItem> ParameterSelections { get; set; } = new ObservableItemCollection<ParameterSelectionItem>();

		public ParamsPresetItem()
		{
			RegisterChildItemCollection(ParameterSelections);
		}
	}
}
