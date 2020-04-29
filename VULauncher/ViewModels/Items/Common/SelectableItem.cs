using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels.Items.Common
{
    public abstract class SelectableItem : ViewModel, ISelectableItem
    {
        private bool _isChecked = true;

        protected virtual bool CanSetChecked => true;

        public bool IsChecked
        {
            get => _isChecked;
            set
            { 
                if (CanSetChecked) 
                    SetField(ref _isChecked, value, setDirty: true); 
            }
        }
    }
}
