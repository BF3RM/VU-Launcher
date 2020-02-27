using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class ServerParamsPreset : PresetEntity
    {
        public List<Parameter> Parameters = new List<Parameter>();
    }
}
