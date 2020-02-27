using System.Linq;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class StartupsViewModel : PresetTabViewModel<StartupPresetItem>
    {
        public override string TabHeaderName { get; } = "Startups";

        public StartupsViewModel()
        {
            Presets.AddRange(StartupPresetsRepository.Instance.StartupPresets);
            SelectedPreset = Presets.FirstOrDefault();

            RegisterChildItemCollection(Presets);
        }
    }
}
