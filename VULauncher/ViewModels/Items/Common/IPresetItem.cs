using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Items.Common
{
    public interface IPresetItem : IObservableObject
    {
        string Name { get; set; }
    }
}
