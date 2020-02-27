using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class BanListPresetsRepository : FileRepository
    {
        private static readonly Lazy<BanListPresetsRepository> _lazy = new Lazy<BanListPresetsRepository>(() => new BanListPresetsRepository());
        public static BanListPresetsRepository Instance => _lazy.Value;

        public List<BanListPresetItem> BanListPresets = new List<BanListPresetItem>();

        private BanListPresetsRepository()
        {
            base.Initialize();
        }

        public override void Load() // TODO: DUMMY
        {
            var banListPreset = new BanListPresetItem()
            {
                Name = "BanList_Preset",
            };

            var banList = new List<BannedPlayerItem>()
            {
                new BannedPlayerItem()
                {
                    Index = 0,
                    PlayerName = "3ti65",
                    PlayerIp = "15.17.197.58",
                    BanReason = "Gaylord",
                    BanDate = new DateTime(2019, 11, 1),
                    UnbanDate = new DateTime(2020, 1, 30),
                    IsDirty = false,
                },

                new BannedPlayerItem()
                {
                    Index = 0,
                    PlayerName = "Powback",
                    PlayerIp = "122.209.98.88",
                    BanReason = "Straightlord",
                    BanDate = new DateTime(2019, 11, 3),
                    UnbanDate = new DateTime(2020, 5, 11),
                    IsDirty = false,
                },
            };

            banListPreset.BannedPlayers.AddRange(banList);
            banListPreset.IsDirty = false;

            BanListPresets.Add(banListPreset);
        }
    }
}
