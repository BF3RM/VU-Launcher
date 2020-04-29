using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace VULauncher.Models.Config
{
    public static class Configuration
    {
        public static string Bf3DocumentsDirectory
        {
            get => ConfigurationManager.AppSettings["Bf3DocumentsDirectory"];
            set => ConfigurationManager.AppSettings["Bf3DocumentsDirectory"] = value;
        }

        public static string VUInstallationDirectory
        {
            get => ConfigurationManager.AppSettings["VUInstallationDirectory"];
            set => ConfigurationManager.AppSettings["VUInstallationDirectory"] = value;
        }

        public static string UserDataDirectory => Directory.GetCurrentDirectory();
        public static string ServerDirectory => Path.Combine(Bf3DocumentsDirectory, "Server");
        public static string AdminDirectory => Path.Combine(ServerDirectory, "Admin");
        public static string ModsDirectory => Path.Combine(AdminDirectory, "Mods");
        public static string VUBinariesDirectory => Path.Combine(VUInstallationDirectory, "client");
    }
}
