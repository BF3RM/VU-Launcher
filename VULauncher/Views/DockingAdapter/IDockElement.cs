using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.Windows.Tools.Controls;

namespace VULauncher.Views.DockingAdapter
{
    public interface IDockElement
    {
        string Header { get; set; }

        DockState State { get; set; }
    }
}
