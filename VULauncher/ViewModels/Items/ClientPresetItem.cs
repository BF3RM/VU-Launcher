using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ClientPresetItem : PresetItem
    {
        private FrequencyType _frequencyType = FrequencyType._30Hz;
        private ClientParamsPresetItem _clientParamsPreset;
        private bool _sendRuntimeErrorDumps = true;
        private bool _openConsole = true;

        public FrequencyType FrequencyType
        {
            get => _frequencyType;
            set => SetField(ref _frequencyType, value, setDirty: true);
        }

        public ClientParamsPresetItem ClientParamsPreset
        {
            get => _clientParamsPreset;
            set => SetField(ref _clientParamsPreset, value, setDirty: true);
        }

        public bool SendRuntimeErrorDumps
        {
            get => _sendRuntimeErrorDumps;
            set => SetField(ref _sendRuntimeErrorDumps, value, setDirty: true);
        }

        public bool OpenConsole
        {
            get => _openConsole;
            set => SetField(ref _openConsole, value, setDirty: true);
        }
    }
}
