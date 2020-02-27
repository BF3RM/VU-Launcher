using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class ModSelection : Entity
    {
        public string DisplayName { get; set; }
        public bool IsChecked { get; set; }
    }
}
