using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Items.Common
{
    public interface ISelectableItem
    {
        bool IsChecked { get; set; }
        string DisplayName { get; set; }
    }
}
