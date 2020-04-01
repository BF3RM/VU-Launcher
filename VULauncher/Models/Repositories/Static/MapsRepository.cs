using System;
using System.Collections.Generic;
using VULauncher.Models.Entities;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Repositories.Static
{
    public class MapsRepository : StaticRepository
    {
        private static readonly Lazy<MapsRepository> _lazy = new Lazy<MapsRepository>(() => new MapsRepository());
        public static MapsRepository Instance => _lazy.Value;

        public List<Map> Maps = new List<Map>();

        public MapsRepository()
        {
            Maps.AddRange(new List<Map>()
            {
                new Map()
                {
                    MapType = MapType.MP_001,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_003,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_007,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_011,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_012,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_013,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_017,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_018,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.MP_Subway,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP1_001,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestAssaultSmall1,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP1_002,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP1_003,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestAssaultSmall1,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP1_004,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestAssaultSmall1,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP2_Factory,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.Domination0,
                        GameModeType.GunMaster0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP2_Office,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.Domination0,
                        GameModeType.GunMaster0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP2_Palace,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.Domination0,
                        GameModeType.GunMaster0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP2_Skybar,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.Domination0,
                        GameModeType.GunMaster0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP3_Alborz,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TankSuperiority0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP3_Desert,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TankSuperiority0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP3_Shield,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TankSuperiority0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP3_Valley,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TankSuperiority0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP4_FD,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.GunMaster0,
                        GameModeType.RushLarge0,
                        GameModeType.Scavenger0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP4_Parl,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.GunMaster0,
                        GameModeType.RushLarge0,
                        GameModeType.Scavenger0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP4_Quake,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.GunMaster0,
                        GameModeType.RushLarge0,
                        GameModeType.Scavenger0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP4_Rubble,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.GunMaster0,
                        GameModeType.RushLarge0,
                        GameModeType.Scavenger0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP5_001,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.AirSuperiority0,
                        GameModeType.CaptureTheFlag0,
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP5_002,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.AirSuperiority0,
                        GameModeType.CaptureTheFlag0,
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP5_003,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.AirSuperiority0,
                        GameModeType.CaptureTheFlag0,
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                },

                new Map()
                {
                    MapType = MapType.XP5_004,
                    GameModeTypes = new List<GameModeType>()
                    {
                        GameModeType.AirSuperiority0,
                        GameModeType.CaptureTheFlag0,
                        GameModeType.ConquestAssaultLarge0,
                        GameModeType.ConquestAssaultSmall0,
                        GameModeType.ConquestLarge0,
                        GameModeType.ConquestSmall0,
                        GameModeType.RushLarge0,
                        GameModeType.SquadDeathMatch0,
                        GameModeType.SquadRush0,
                        GameModeType.TeamDeathMatch0,
                        GameModeType.TeamDeathMatchC0
                    },
                }
            });
        }
    }
}
