using System;
using System.IO;
using VULauncher.Models.Config;
using VULauncher.Models.Repositories.Common;

namespace VULauncher.Models.Repositories.UserData
{
	public class StartupTextFileRepository : TextFileRepository
	{
		private static readonly Lazy<StartupTextFileRepository> _lazy = new Lazy<StartupTextFileRepository>(() => new StartupTextFileRepository());
		public static StartupTextFileRepository Instance => _lazy.Value;

		public string DefaultStartupContent = @$"
                admin.password superelitepassword

                vars.serverName '<YOUR_SERVER_NAME>'
                vars.gamePassword '<YOUR_SERVER_PASSWORD>'
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
                ";

        public StartupTextFileRepository() 
            : base(Configuration.StartupFilePath)
        {
        }

		public void WriteStartupFile(string startupFileContent)
		{
			OverwriteFile(startupFileContent);
		}
    }
}
