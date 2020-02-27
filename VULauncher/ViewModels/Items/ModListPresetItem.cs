using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ModListPresetItem : PresetItem
    {
        public ObservableItemCollection<ModSelectionItem> ModSelection { get; set; } = new ObservableItemCollection<ModSelectionItem>();

        public ModListPresetItem()
        {
            RegisterChildItemCollection(ModSelection);
        }
    }
}
