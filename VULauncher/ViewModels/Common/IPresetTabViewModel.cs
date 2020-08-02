using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Common
{
    public interface IPresetTabViewModel : ITabViewModel
    {
        bool IsDirty { get; }
        void SetSelectedPreset(int selectedPresetId);
        void Save();
        void ReloadItems();
        void DiscardChanges();
        IEnumerable<ValidationError> GetValidationErrors();
    }
}
