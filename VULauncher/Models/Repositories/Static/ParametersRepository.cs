using System;
using System.Collections.Generic;
using System.Linq;
using VULauncher.Models.Entities;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Repositories.Static
{
    public class ParametersRepository : StaticRepository
    {
        private static readonly Lazy<ParametersRepository> _lazy = new Lazy<ParametersRepository>(() => new ParametersRepository());
        public static ParametersRepository Instance => _lazy.Value;

        public List<LaunchParameter> AllParameters = new List<LaunchParameter>();
        public List<LaunchParameter> ClientParameters = new List<LaunchParameter>();
        public List<LaunchParameter> ServerParameters = new List<LaunchParameter>();

        private ParametersRepository()
        {
            AllParameters.AddRange(new List<LaunchParameter>()
            {
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "gamePath", ExpectedValue = "<path>", Description = "Used to explicitly specify the Battlefield 3 installation directory." }, // TODO: add AdditionalParameter <bf3 path>
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "perftrace", Description = "Writes a performance profile to perftrace-[server|client].csv." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "env", ExpectedValue = "[prod|dev]", Description = "Specifies the Zeus environment to connect to. Defaults to prod." }, // TODO: add AdditionalParameter <prod|dev>
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "updateBranch", ExpectedValue = "[prod|dev]", Description = "Specifies the update branch to fetch updates from. Defaults to whatever -env is set to." }, // TODO: add AdditionalParameter <prod|dev>
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "tracedc", Description = "Traces DataContainer usage in VEXT and prints any dangling DCs during level destuction." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "cacert", ExpectedValue = "<path>", Description = "Sets a custom CA certificate bundle to use for SSL verification." }, // TODO: add AdditionalParameter <cacert.pem path>
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "activate", ExpectedValue = "-o_mail <email> -o_pass <pass>", Description = "Activates BF3 on the current machine using the specified Origin credentials." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "console", Description = "Allocates an external console window for debug logging." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "debuglog", Description = "Saves logging output to a file in the logs folder. For servers, this folder will be in the server instance directory. For clients, it will be in the VU AppData installation folder." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "trace", Description = "Enables verbose logging." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "vextdebug", ExpectedValue = "<host:port>", Description = "Enables VEXT remote debugging, connecting to the debugger at the specified host:port (this does not currently work). It also prevents the server / client connections from timing out and makes it so compiled VEXT modules sent to the client contain debug symbols." },
                new LaunchParameter() { Realm = RealmType.Shared, ParameterString = "vexttrace", Description = "Enables VEXT execution tracing. When tracing is enabled and VU crashes, the last executed line of each loaded VEXT mod will be available from the crash dialog and in the submitted crash details. Keep in mind that this could adversely affect performance." },

                new LaunchParameter() { Realm = RealmType.Client, ParameterString = "dwebui", Description = "Enables WebUI debugging at http://localhost:8884." },
                new LaunchParameter() { Realm = RealmType.Client, ParameterString = "cefdebug", Description = "Enable verbose debugging logging for CEF. Useful for catching issues with WebUI mods. When running with this argument, a debug.log file will be created in the directory of VU (usually %LocalAppData%\VeniceUnleashed\client)." },

                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "server", IsMandatory = true, Description = "Required argument for running a VU server." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "dedicated", IsMandatory = true, Description = "Required argument for running a VU server." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "high60", Description = "Sets the VU server frequency to 60Hz." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "high120", Description = "Sets the VU server frequency to 120Hz." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "headless", Description = "Runs the VU server in headless mode (without creating any windows)." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "serverInstancePath", ExpectedValue = "<path>", Description = "Sets the server instance path (where the server configuration, logs, and mods are stored) for the VU server." }, // TODO: add AdditionalParameter <path>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "highResTerrain", Description = "Enables high resolution terrain. Useful for extending maps beyond their original play area." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "disableTerrainInterp", Description = "Disables interpolation between different terrain LODs." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "skipChecksum", Description = "Disables level checksum validation on client connection." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "listen", ExpectedValue = "<host:port>", Description = "Sets the host and port the VU server should listen for connections on. Defaults to 0.0.0.0:25200." }, // TODO: add AdditionalParameter <host:port>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "mHarmonyPort", ExpectedValue = "<port>", Description = "Sets the port the VU server should listen for MonitoredHarmony connections. Defaults to 7948." }, // TODO: add AdditionalParameter <port>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "RemoteAdminPort", ExpectedValue = "<host:port>", Description = "Sets the host and port the VU server should listen for RCON connections. Defaults to 0.0.0.0:47200." }, // TODO: add AdditionalParameter <host:port>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "unlisted", Description = "Makes the server not show up in the server list. Unlisted servers can only be joined by the connect console command or via the vu://join/server-id url scheme, which can also be added as a launch argument to vu.exe to auto-join as soon as the client loads." },
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "joinaddr", ExpectedValue = "<ip>", Description = "Specifies the IP address clients should connect to in order to join this server. Only IPv4 addresses are supported. If you don't specify this, the backend will attempt to automatically detect the server's IP address." }, // TODO: add AdditionalParameter <ip>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "joinhost", ExpectedValue = "<hostname>", Description = "Specifies a hostname clients should use when connecting to this server. When this is specified -joinaddr has no effect and any clients attempting to connect will not attempt to perform any NAT detection." }, // TODO: add AdditionalParameter <hostname>
                new LaunchParameter() { Realm = RealmType.Server, ParameterString = "noUpdate", Description = "Disables automatic updates." },
            });

            ClientParameters.AddRange(AllParameters.Where(p => p.IsClient));
            ServerParameters.AddRange(AllParameters.Where(p => p.IsServer));
        }
    }
}
