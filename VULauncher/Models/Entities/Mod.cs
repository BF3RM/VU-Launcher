using System;
using System.Collections.Generic;
using System.Text;
using VULauncher.Models.Entities.Common;

namespace VULauncher.Models.Entities
{
    public class Mod : Entity
    {
        //Name: "RealityMod",
        //Authors: "Powback" , "3ti65", "FoolHen", "Mitsu", "Hattiwatti",
        //Description: "A 'Project Reality'-Style mod for Battlefield 3",
        //URL: "none",
        //Version: "0.1",
        //HasWebUI: true,
        //HasVeniceEXT: true

        public string Name { get; set; }
        public List<string> Authors { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string Version { get; set; }
        public bool HasWebUi { get; set; }
        public bool HasVeniceExt { get; set; }
    }
}
