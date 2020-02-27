using System.Linq;
using VULauncher.Models.Repositories;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class BanListsViewModel : PresetTabViewModel<BanListPresetItem>
    {
        public override string TabHeaderName { get; } = "BanLists";

        public BanListsViewModel()
        {
            Presets.AddRange(BanListPresetsRepository.Instance.BanListPresets);
            SelectedPreset = Presets.FirstOrDefault();

            RegisterChildItemCollection(Presets);
        }
    }
}
