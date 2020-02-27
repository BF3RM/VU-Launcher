using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class BanListPresetItem : PresetItem
    {
        public ObservableItemCollection<BannedPlayerItem> BannedPlayers { get; set; } = new ObservableItemCollection<BannedPlayerItem>();

        public BanListPresetItem()
        {
            RegisterChildItemCollection(BannedPlayers);
        }
    }
}
