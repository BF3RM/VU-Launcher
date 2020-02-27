using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;
using VULauncher.ViewModels.Enums;

namespace VULauncher.Models.Entities
{
    public class Parameter : Entity
    {
        public RealmType Realm { get; set; }
        public string DisplayName { get; set; }
        public string AdditionalParameter { get; set; }

        public bool IsClient => Realm == RealmType.Client || Realm == RealmType.Shared;
        public bool IsServer => Realm == RealmType.Server || Realm == RealmType.Shared;
    }
}
