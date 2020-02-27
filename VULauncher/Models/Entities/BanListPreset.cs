using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class BanListPreset : PresetEntity
    {
        public List<BannedPlayer> BannedPlayers = new List<BannedPlayer>();
    }
}
