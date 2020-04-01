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

        public List<Parameter> AllParameters = new List<Parameter>();
        public List<Parameter> ClientParameters = new List<Parameter>();
        public List<Parameter> ServerParameters = new List<Parameter>();

        private ParametersRepository()
        {
            AllParameters.AddRange(new List<Parameter>()
            {
                new Parameter() { DisplayName = "headless", Realm = RealmType.Server},
                new Parameter() { DisplayName = "serverInstancePath", Realm = RealmType.Server}, // TODO: add AdditionalParameter <path>
                new Parameter() { DisplayName = "highResTerrain", Realm = RealmType.Server},
                new Parameter() { DisplayName = "disableTerrainInterp", Realm = RealmType.Server},
                new Parameter() { DisplayName = "high60", Realm = RealmType.Server},
                new Parameter() { DisplayName = "high120", Realm = RealmType.Server},
                new Parameter() { DisplayName = "skipChecksum", Realm = RealmType.Server},
                new Parameter() { DisplayName = "mHarmonyPort", Realm = RealmType.Server}, // TODO: add AdditionalParameter <port>
                new Parameter() { DisplayName = "listen", Realm = RealmType.Server}, // TODO: add AdditionalParameter <host:port>
                new Parameter() { DisplayName = "RemoteAdminPort", Realm = RealmType.Server}, // TODO: add AdditionalParameter <host:port>

                new Parameter() { DisplayName = "dwebui", Realm = RealmType.Client},
                new Parameter() { DisplayName = "multi", Realm = RealmType.Client},

                new Parameter() { DisplayName = "env", Realm = RealmType.Shared}, // TODO: add AdditionalParameter <prod|dev>
                new Parameter() { DisplayName = "updateBranch", Realm = RealmType.Shared}, // TODO: add AdditionalParameter <prod|dev>
                new Parameter() { DisplayName = "tracedc", Realm = RealmType.Shared},
                new Parameter() { DisplayName = "cacert", Realm = RealmType.Shared}, // TODO: add AdditionalParameter <cacert.pem path>
                new Parameter() { DisplayName = "vudebug", Realm = RealmType.Shared},
                new Parameter() { DisplayName = "vextdebug", Realm = RealmType.Shared},
                new Parameter() { DisplayName = "debug", Realm = RealmType.Shared},
                new Parameter() { DisplayName = "gamePath", Realm = RealmType.Shared}, // TODO: add AdditionalParameter <bf3 path>
            });

            ClientParameters.AddRange(AllParameters.Where(p => p.IsClient));
            ServerParameters.AddRange(AllParameters.Where(p => p.IsServer));
        }
    }
}
