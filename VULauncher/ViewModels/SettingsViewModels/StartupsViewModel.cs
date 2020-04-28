using System.Linq;
using VULauncher.Models.PresetProviders;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class StartupsViewModel : PresetTabViewModel<StartupPresetItem, StartupPresetsProvider>
    {
        public override string TabHeaderName { get; } = "Startups";
        public StartupsViewModel()
            : base(StartupPresetsProvider.Instance)
        {
            RegisterChildItemCollection(Presets);
        }
    }
}
