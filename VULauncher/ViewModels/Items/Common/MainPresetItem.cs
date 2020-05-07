using System;
using System.Collections.Generic;
using System.Text;

namespace VULauncher.ViewModels.Items.Common
{
    public interface ILaunchPresetItem
    {
        string Name { get; set; }
        bool OpenConsole { get; }
        IEnumerable<ParameterSelectionItem> GetSelectedParameters();
    }
}
