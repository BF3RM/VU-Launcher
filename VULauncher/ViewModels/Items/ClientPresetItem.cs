using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.Items
{
    public class ClientPresetItem : PresetItem, ILaunchPresetItem
    {
        private ClientParamsPresetItem _clientParamsPreset;
        private bool _sendRuntimeErrorDumps = true;
        private bool _openConsole = true;

        public bool HasMultiParameterSelected
        {
            get => ClientParamsPreset != null && ClientParamsPreset.ParameterSelections.First(p => p.ParameterString == "multi").IsChecked;
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

        public IEnumerable<ParameterSelectionItem> GetSelectedParameters()
        {
            if (ClientParamsPreset == null)
                return Enumerable.Empty<ParameterSelectionItem>();

            return ClientParamsPreset.ParameterSelections.Where(p => p.IsChecked);
        }

        public override IEnumerable<ValidationError> GetValidationErrors()
        {
            var validationErrors = new List<ValidationError>();

            if (ClientParamsPreset == null)
                validationErrors.Add(new ValidationError($"Client Params Preset must be set on Client Preset '{Name}'"));

            return validationErrors;
        }
    }
}
