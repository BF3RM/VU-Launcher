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
            RegisterChildItemCollection(Parameters);
        }

        public ObservableItemCollection<ParameterSelectionItem> Parameters { get; set; } = new ObservableItemCollection<ParameterSelectionItem>();
    }
}
