using System.Linq;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientParamsViewModel : PresetTabViewModel<ClientParamsPresetItem>
    {
        public override string TabHeaderName { get; } = "Client Params";

        public ClientParamsViewModel()
        {
            Presets.AddRange(ClientParamsPresetsRepository.Instance.ClientParamsPresets);
            SelectedPreset = Presets.FirstOrDefault();

            RegisterChildItemCollection(Presets);
        }
    }
}
