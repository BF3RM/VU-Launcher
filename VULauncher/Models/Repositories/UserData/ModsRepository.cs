using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using VULauncher.Models.Config;
using VULauncher.Models.Entities;
using VULauncher.Models.Repositories.Common;

namespace VULauncher.Models.Repositories.UserData
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

        protected override void Load() //TODO: DUMMY
        {
            var files = Directory.EnumerateDirectories(Configuration.ModsDirectory).SelectMany(directory => Directory.EnumerateFiles(directory, "mod.json"));

            foreach (var modFile in files)
            {
                try
                {
                    var mod = JsonConvert.DeserializeObject<Mod>(File.ReadAllText(modFile));
                    Mods.Add(mod);
                }
                catch (Exception ex)
                {
                    // todo: process invalid mod.jsons?
                }
            }
        }
    }
}
