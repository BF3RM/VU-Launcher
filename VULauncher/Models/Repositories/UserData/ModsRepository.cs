using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities;
using VULauncher.Models.Repositories.Common;
using VULauncher.ViewModels.Items;

namespace VULauncher.Models.Repositories
{
    public class ModsRepository : FileRepository
    {
        private static readonly Lazy<ModsRepository> _lazy = new Lazy<ModsRepository>(() => new ModsRepository());
        public static ModsRepository Instance => _lazy.Value;

        public List<Mod> Mods = new List<Mod>();

        public ModsRepository()
        {
            base.Initialize();
        }

        public override void Load() //TODO: DUMMY
        {
            var mod = new Mod()
            {
                Name = "testmod",
                Authors = new List<string>() { "3ti", "Pow" },
                Description = "bla",
                Url = "bla.com",
                Version = "ver1",
                HasVeniceExt = true,
                HasWebUi = true,
            };

            Mods.Add(mod);
        }
    }
}
