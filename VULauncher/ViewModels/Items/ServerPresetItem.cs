using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ServerPresetItem : PresetItem, ILaunchPresetItem
    {
        private bool _openConsole = true;
        private ServerParamsPresetItem _serverParamsPreset;
        private MapListPresetItem _mapListPreset;
        private StartupPresetItem _startupPreset;
        private BanListPresetItem _banListPreset;

        public ObservableItemCollection<ModSelectionItem> ModSelections { get; set; } = new ObservableItemCollection<ModSelectionItem>();

        public ServerPresetItem()
        {
	        RegisterChildItemCollection(ModSelections);
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
                validationErrors.Add(new ValidationError($"BanList Preset must be set on Server Preset '{Name}'"));

            return validationErrors;
        }
    }
}
