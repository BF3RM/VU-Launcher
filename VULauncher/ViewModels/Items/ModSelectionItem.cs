using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ModSelectionItem : SelectableItem, IUserEditableItem
    {
        public string ModName { get; set; }

        public int Id { get; set; }
        public bool IsNew => Id == 0;
    }
}
