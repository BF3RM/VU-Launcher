using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class ServerParamsViewModel : PresetTabViewModel<ServerParamsPresetItem, ServerParamsPresetsProvider>
    {
        public override string TabHeaderName => "Server Params";
        protected override string NewPresetExampleName => "My_Server_Parameters";

        public ServerParamsViewModel()
            : base(ServerParamsPresetsProvider.Instance)
        {
        }
    }
}
