using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual IEnumerable<ValidationError> GetValidationErrors()
        {
            return Enumerable.Empty<ValidationError>();
        }

        public int Id { get; set; }

        public override bool Equals(object obj)
        {
	        var item = obj as PresetItem;

	        if (item == null)
	        {
		        return false;
	        }

	        return this.Id.Equals(item.Id);
        }

        public override int GetHashCode()
        {
	        return this.Id.GetHashCode();
        }
    }
}
