using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientParamsViewModel : PresetTabViewModel<ClientParamsPresetItem, ClientParamsPresetsProvider>
    {
        public override string TabHeaderName => "Client Params";
        protected override string NewPresetExampleName => "My_Client_Parameters";

        public ClientParamsViewModel()
            : base(ClientParamsPresetsProvider.Instance)
        {
            RegisterChildItemCollection(Presets);
        }
    }
}
