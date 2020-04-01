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

        protected override string SubDirectory => "BanLists";

        protected override IEnumerable<BanListPreset> ConvertItemsToEntities(IEnumerable<BanListPresetItem> presetItems)
        {
            return presetItems.ToEntityList();
        }

        protected override IEnumerable<BanListPresetItem> ConvertEntitiesToItems(IEnumerable<BanListPreset> presetEntities)
        {
            return presetEntities.ToItemList();
        }

        public BanListPresetsProvider()
        {
            LoadDummyData();
        }

        private void LoadDummyData() // TODO: DUMMY
        {
            var banListPreset = new BanListPresetItem()
            {
                Name = "BanList_Preset",
            };

            var banList = new List<BannedPlayer>()
            {
                new BannedPlayer()
                {
                    Index = 0,
                    PlayerName = "3ti65",
                    PlayerIp = "15.17.197.58",
                    BanReason = "Gaylord",
                    BanDate = new DateTime(2019, 11, 1),
                    UnbanDate = new DateTime(2020, 1, 30),
                },

                new BannedPlayer()
                {
                    Index = 0,
                    PlayerName = "Powback",
                    PlayerIp = "122.209.98.88",
                    BanReason = "Straightlord",
                    BanDate = new DateTime(2019, 11, 3),
                    UnbanDate = new DateTime(2020, 5, 11),
                },
            };

            banListPreset.BannedPlayers.AddRange(banList.ToItemList());
            //banListPreset.IsDirty = false; // treat it like user input

            PresetItems.Add(banListPreset);
        }
    }
}
