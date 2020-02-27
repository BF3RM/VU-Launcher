using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class BannedPlayer : Entity
    {
        public int Index { get; set; }
        public string PlayerName { get; set; }
        public string PlayerIp { get; set; }
        public DateTime BanTime { get; set; }
        public DateTime UnbanTime { get; set; }
        public string BanReason { get; set; }
    }
}
