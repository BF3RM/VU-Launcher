using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items.Extensions
{
    public static class PresetItemValidationExtensions
    {
        public static IEnumerable<ValidationError> GetValidationErrors(this IEnumerable<PresetItem> presetItems)
        {
            return presetItems.SelectMany(p => p.GetValidationErrors());
        }
    }
}
