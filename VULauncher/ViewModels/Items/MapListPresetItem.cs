using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class MapListPresetItem : PresetItem
    {
        public ObservableItemCollection<MapSelectionItem> MapSelections { get; set; } = new ObservableItemCollection<MapSelectionItem>();

        public MapListPresetItem()
        {
            RegisterChildItemCollection(MapSelections);
        }
    }
}
