using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class StartupPresetsRepository : FileRepository
    {
        private static readonly Lazy<StartupPresetsRepository> _lazy = new Lazy<StartupPresetsRepository>(() => new StartupPresetsRepository());
        public static StartupPresetsRepository Instance => _lazy.Value;

        public List<StartupPresetItem> StartupPresets = new List<StartupPresetItem>();

        private StartupPresetsRepository()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var startupPreset = new StartupPresetItem()
            {
                Name = "RM_Dedi_Startup",
                StartupFileContent = @"
                admin.password superelitepassword

                vars.serverName '[RM_DEV] 3ti65`s God Tier PC\'
                vars.gamePassword ''
                vars.serverDescription ''
                vars.friendlyFire true
                vars.idleTimeout 0
                vars.teamKillCountForKick 0
                vars.teamKillValueForKick 0
                vars.teamKillValueIncrease 0
                vars.teamKillValueDecreasePerSecond 0
                vars.killCam false
                vars.miniMap true
                vars.3dSpotting true
                vars.miniMapSpotting true
                vars.3pCam false
                vars.maxPlayers 100
                vars.idleBanRounds 0
                vars.vehicleSpawnAllowed true
                vars.vehicleSpawnDelay 100
                vars.bulletDamage 100
                vars.nameTag true
                vars.regenerateHealth true
                vars.roundRestartPlayerCount 0
                vars.roundStartPlayerCount 0
                vars.onlySquadLeaderSpawn true
                vars.gunMasterWeaponsPreset 0
                vars.soldierHealth 100
                vars.hud true
                vars.playerManDownTime 100
                vars.playerRespawnTime 100
                vars.gameModeCounter 125
                vars.ctfRoundTimeModifier 100
                vars.roundLockdownCountdown 15
                vars.roundWarmupTimeout 600
                vars.premiumStatus false

                ## VU Settings
                vu.ColorCorrectionEnabled false
                vu.SunFlareEnabled false
                vu.SuppressionMultiplier 0
                vu.VehicleDisablingEnabled false
                vu.HighPerformanceReplication true
                vu.DesertingAllowed true
                ",
                IsDirty = false,
            };

            StartupPresets.Add(startupPreset);
        }
    }
}
