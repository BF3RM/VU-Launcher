using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Items.Common
{
    public abstract class PresetItem : ItemsParentViewModel, IPresetItem
    {
        private string _name;

        public string Name
        {
            get => _name;
            set => SetField(ref _name, value, setDirty: true);
        }

        public int Id { get; set; }
    }
}
