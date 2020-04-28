using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ClientParamsPresetItem : PresetItem
    {
        public ClientParamsPresetItem()
        {
            RegisterChildItemCollection(ParameterSelections);
        }

        public ObservableItemCollection<ParameterSelectionItem> ParameterSelections { get; set; } = new ObservableItemCollection<ParameterSelectionItem>();
    }
}
