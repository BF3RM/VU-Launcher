using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Common
{
    public interface IPresetTabViewModel : ITabViewModel
    {
        bool IsDirty { get; }
        void SetSelectedPreset(int selectedPresetId);
        void Save();
        void DiscardChanges();
    }
}
