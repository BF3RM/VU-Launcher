using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Syncfusion.Windows.Shared;
using VULauncher.Views.DockingAdapter;

namespace VULauncher.ViewModels.Common
{
    public class DockingViewModel : NotificationObject, IDockElement
    {
        [ReadOnly(true)]
        public string Header { get; set; }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public DockState State { get; set; } = DockState.Dock;
    }
}
