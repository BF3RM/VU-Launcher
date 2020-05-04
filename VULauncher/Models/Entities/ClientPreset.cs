using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Entities
{
    public class ClientPreset : PresetEntity
    {
        public int ClientParamsPresetId { get; set; }
        public bool SendRuntimeErrorDumps { get; set; }
        public bool OpenConsole { get; set; }
    }
}
