using System.Linq;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientPresetsViewModel : PresetTabViewModel<ClientPresetItem>
    {
        public override string TabHeaderName { get; } = "Client Presets";
        public WpfObservableRangeCollection<ClientParamsPresetItem> ClientParamsPresets { get; set; } = new WpfObservableRangeCollection<ClientParamsPresetItem>();

        public ClientPresetsViewModel()
        {
            Presets.AddRange(ClientPresetsRepository.Instance.ClientPresets);
            SelectedPreset = Presets.FirstOrDefault();
            ClientParamsPresets.AddRange(ClientParamsPresetsRepository.Instance.ClientParamsPresets);
        }
    }
}
