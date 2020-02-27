using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ParameterSelectionItem : SelectableItem
    {
        public string AdditionalParameter { get; set; } 

        public string StartupString
        {
            get => AdditionalParameter == null 
                ? $"-{DisplayName}"
                : $"-{DisplayName} {AdditionalParameter}";
        }
    }
}
