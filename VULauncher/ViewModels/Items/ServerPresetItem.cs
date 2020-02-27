using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ServerPresetItem : PresetItem
    {
        private FrequencyType _frequencyType = FrequencyType._30Hz;
        private ServerParamsPresetItem _serverParamsPreset;
        private MapListPresetItem _mapListPreset;
        private StartupPresetItem _startupPreset;
        private BanListPresetItem _banListPreset;
        private bool _sendRuntimeErrorDumps = true;
        private bool _openConsole = true;

        public FrequencyType FrequencyType
        {
            get => _frequencyType;
            set => SetField(ref _frequencyType, value, setDirty: true);
        }

        public ModListPresetItem ModListPreset { get; set; }

        public ServerParamsPresetItem ServerParamsPreset
        {
            get => _serverParamsPreset;
            set => SetField(ref _serverParamsPreset, value, setDirty: true);
        }

        public MapListPresetItem MapListPreset
        {
            get => _mapListPreset;
            set => SetField(ref _mapListPreset, value, setDirty: true);
        }

        public StartupPresetItem StartupPreset
        {
            get => _startupPreset;
            set => SetField(ref _startupPreset, value, setDirty: true);
        }

        public BanListPresetItem BanListPreset
        {
            get => _banListPreset;
            set => SetField(ref _banListPreset, value, setDirty: true);
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
