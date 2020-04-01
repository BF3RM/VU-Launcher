using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientParamsViewModel : PresetTabViewModel<ClientParamsPresetItem, ClientParamsPresetsProvider>
    {
        public override string TabHeaderName { get; } = "Client Params";

        public ClientParamsViewModel()
            : base(ClientParamsPresetsProvider.Instance)
        {
            RegisterChildItemCollection(Presets);
        }
    }
}
