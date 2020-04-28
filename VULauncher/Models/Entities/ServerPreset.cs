using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Entities
{
    public class ServerPreset : PresetEntity
    {
        public FrequencyType FrequencyType { get; set; }
        public int ServerParamsPresetId { get; set; }
        public int MapListPresetId { get; set; }
        public int ModListPresetId { get; set; }
        public int StartupPresetId { get; set; }
        public int BanListPresetId { get; set; }
        public bool SendRuntimeErrorDumps { get; set; }
        public bool OpenConsole { get; set; }
    }
}
