using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Entities.Extensions;
using VULauncher.Models.PresetProviders.Common;
using VULauncher.Models.Repositories.UserData;
using VULauncher.ViewModels.Items;
using VULauncher.ViewModels.Items.Common;

namespace VULauncher.Models.PresetProviders
{
    public class BanListPresetsProvider : PresetsProvider<BanListPreset, BanListPresetItem>
    {
        private static readonly Lazy<BanListPresetsProvider> _lazy = new Lazy<BanListPresetsProvider>(() => new BanListPresetsProvider());
        public static BanListPresetsProvider Instance => _lazy.Value;

        protected override string FileName => "BanLists";

        protected override IEnumerable<BanListPreset> ConvertItemsToEntities(IEnumerable<BanListPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<BanListPresetItem> ConvertEntitiesToItems(IEnumerable<BanListPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }
    }
}
