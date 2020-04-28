using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Entities
{
    public class LaunchParameter : Entity
    {
        public bool IsMandatory { get; set; }
        public RealmType Realm { get; set; }
        public string ParameterString { get; set; }
        public string ExpectedValue { get; set; }
        public string Description { get; set; }

        public bool IsClient => Realm == RealmType.Client || Realm == RealmType.Shared;
        public bool IsServer => Realm == RealmType.Server || Realm == RealmType.Shared;
    }
}
