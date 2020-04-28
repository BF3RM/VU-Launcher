using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Collections;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ClientPresetsViewModel : PresetTabViewModel<ClientPresetItem, ClientPresetsProvider>
    {
        public override string TabHeaderName { get; } = "Client Presets";
        public ClientParamsViewModel ClientParamsViewModel { get; set; }

        public ClientPresetsViewModel(ClientParamsViewModel clientParamsViewModel)
            : base(ClientPresetsProvider.Instance)
        {
            ClientParamsViewModel = clientParamsViewModel;

            RegisterChildItemCollection(Presets);
        }
    }
}
