using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Entities
{
    public class Map : Entity
    {
        public MapType MapType { get; set; }
        public List<GameModeType> GameModeTypes { get; set; }
    }
}
