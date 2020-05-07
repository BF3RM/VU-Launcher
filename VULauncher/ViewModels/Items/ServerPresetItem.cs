﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ServerPresetItem : PresetItem, ILaunchPresetItem
    {
        private ModListPresetItem _modListPreset;
        private ServerParamsPresetItem _serverParamsPreset;
        private MapListPresetItem _mapListPreset;
        private StartupPresetItem _startupPreset;
        private BanListPresetItem _banListPreset;
        private bool _sendRuntimeErrorDumps = true;
        private bool _openConsole = true;

        public ModListPresetItem ModListPreset
        {
            get => _modListPreset;
            set
            {
                if (SetField(ref _modListPreset, value))
                {
                    if (value != null)
                        RegisterChildItem(value); // since the ModList is a child directly nested into the ServerPresetItem, we want to direclty track it and update the IsDirty accordingly
                }
            }
        }

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

        public IEnumerable<ParameterSelectionItem> GetSelectedParameters()
        {
            if (ServerParamsPreset == null)
                return Enumerable.Empty<ParameterSelectionItem>();

            return ServerParamsPreset.ParameterSelections.Where(p => p.IsChecked);
        }

        public override IEnumerable<ValidationError> GetValidationErrors()
        {
            var validationErrors = new List<ValidationError>();

            if (ServerParamsPreset == null)
                validationErrors.Add(new ValidationError($"Server Params Preset must be set on Server Preset '{Name}'"));

            if (MapListPreset == null)
                validationErrors.Add(new ValidationError($"MapList Preset must be set on Server Preset '{Name}'"));

            if (StartupPreset == null)
                validationErrors.Add(new ValidationError($"Startup Preset must be set on Server Preset '{Name}'"));

            if (BanListPreset == null)
                validationErrors.Add(new ValidationError($"ModList Preset must be set on Server Preset '{Name}'"));

            return validationErrors;
        }
    }
}
