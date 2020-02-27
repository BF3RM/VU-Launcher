using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class StartupPresetItem : PresetItem
    {
        private string _startupFileContent;

        public string StartupFileContent
        {
            get => _startupFileContent;
            set => SetField(ref _startupFileContent, value, setDirty: true);
        }
    }
}
