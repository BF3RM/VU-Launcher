using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Items.Common
{
    public interface IPresetItem : IObservableObject
    {
        int Id { get; set; }
        string Name { get; set; }
        IEnumerable<ValidationError> GetValidationErrors();
    }
}
