using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class StartupsViewModel : PresetTabViewModel<StartupPresetItem, StartupPresetsProvider>
    {
        public override string TabHeaderName => "Startups";
        protected override string NewPresetExampleName => "My_Startup";

        public StartupsViewModel()
            : base(StartupPresetsProvider.Instance)
        {
        }
    }
}
