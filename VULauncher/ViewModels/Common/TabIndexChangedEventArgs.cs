using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public class TabIndexChangedEventArgs : EventArgs
    {
        public TabIndexChangedEventArgs(int newTabIndex)
        {
            NewTabIndex = newTabIndex;
        }

        public int NewTabIndex { get; set; }
    }
}
