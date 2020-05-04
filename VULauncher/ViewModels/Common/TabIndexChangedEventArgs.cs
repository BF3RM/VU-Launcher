using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public class TabIndexChangedEventArgs : EventArgs
    {
        public TabIndexChangedEventArgs(int newTabIndex, int selectedPresetId)
        {
            NewTabIndex = newTabIndex;
            SelectedPresetId = selectedPresetId;
        }

        public int NewTabIndex { get; set; }
        public int SelectedPresetId { get; set; }
    }
}
