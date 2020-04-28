using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ParameterSelectionItem : SelectableItem, IUserEditableItem
    {
        private string _value;

        public bool IsNew => Id == 0;

        public int Id { get; set; }
        public bool IsMandatory { get; set; }
        public string ParameterString { get; set; }
        public string ExpectedValue { get; set; }
        public string Description { get; set; }

        public string Value
        {
            get => _value;
            set => SetField(ref _value, value, setDirty: true);
        }
    }
}
