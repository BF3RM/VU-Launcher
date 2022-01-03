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

        protected override BanListPresetItem CreateNewPresetItem(BanListPresetItem newPresetItem)
        {
            var banListTextFileLines = MapListTextFileRepository.Instance.FileContentLines;

            if (banListTextFileLines.Any())
            {
                for (int i = 0; i < banListTextFileLines.Length; i = i + 4)
                {
                    var identifierType = banListTextFileLines[i];
                    var identifierString = banListTextFileLines[i + 1];
                    var durationType = banListTextFileLines[i + 2]; 
                    var durationAmount = banListTextFileLines[i + 3];

                    newPresetItem.BannedPlayers.Add(new BannedPlayerItem()
                    {
                        Index = i,
                        //PlayerName = playerName,
                        //PlayerIp = playerIp,
                        //BanDate = banDate,
                        //UnbanDate = unbanDate,
                        //BanReason = banReason,
                    });
                }
            }

            return newPresetItem;
        }
    }
}
