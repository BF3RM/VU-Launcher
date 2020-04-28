using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ServerParamsPresetItem : PresetItem
    {
        public ObservableItemCollection<ParameterSelectionItem> ParameterSelections { get; set; } = new ObservableItemCollection<ParameterSelectionItem>();

        public ServerParamsPresetItem()
        {
            RegisterChildItemCollection(ParameterSelections);
        }
    }
}
