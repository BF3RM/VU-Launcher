using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace VULauncher.Models.Config
{
    public static class Configuration
    {
        public static string UserDataDirectory => Directory.GetCurrentDirectory();
        public static string Bf3DocumentsDirectory => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Battlefield 3");
        public static string ServerDirectory => Path.Combine(Bf3DocumentsDirectory, "Server");
        public static string AdminDirectory => Path.Combine(ServerDirectory, "Admin");
        public static string ModsDirectory => Path.Combine(AdminDirectory, "Mods");
    }
}
