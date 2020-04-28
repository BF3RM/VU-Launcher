using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class MapListPreset : PresetEntity
    {
        public List<MapSelection> MapSelections = new List<MapSelection>();
    }
}
