using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.PresetProviders;
using VULauncher.ViewModels.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.ViewModels.SettingsViewModels
{
    public class BanListsViewModel : PresetTabViewModel<BanListPresetItem, BanListPresetsProvider>
    {
        public override string TabHeaderName => "BanLists";
        protected override string NewPresetExampleName => "My_Ban_List";

        public BanListsViewModel()
            : base(BanListPresetsProvider.Instance)
        {
            RegisterChildItemCollection(Presets);
        }
    }
}
