using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public interface IObservableObject
    {
        bool IsDirty { get; }
        event IsDirtyChangedEventHandler IsDirtyChanged;
        event PropertyChangedEventHandler PropertyChanged;
    }
}
