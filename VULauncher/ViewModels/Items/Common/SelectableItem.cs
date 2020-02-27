using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Items.Common
{
    public abstract class SelectableItem : ViewModel, ISelectableItem
    {
        private bool _isChecked;

        public bool IsChecked
        {
            get => _isChecked;
            set => SetField(ref _isChecked, value, setDirty: true);
        }

        public string DisplayName { get; set; }
    }
}
