using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Collections
{
    public interface IPresetCollection<T>
    {
        void Add(T presetItem);
        void AddRange(IEnumerable<T> presetCollection);
        bool Remove(T presetItem);
    }

    public class PresetCollection<T> : ObservableItemCollection<T>, IPresetCollection<T>
        where T : IObservableObject
    {
    }
}
