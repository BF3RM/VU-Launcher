using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class ModListPreset : PresetEntity
    {
        public List<ModSelection> ModSelection = new List<ModSelection>();
    }
}
