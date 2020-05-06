using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using VULauncher.Models.Config;

namespace VULauncher.Models.Setup
{
	public static class LocalSetup
	{
		public static void VerifyOrCreate()
		{
			if (string.IsNullOrEmpty(Configuration.Bf3DocumentsDirectory))
				Configuration.Bf3DocumentsDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Battlefield 3");

			if (string.IsNullOrEmpty(Configuration.VUInstallationDirectory))
				Configuration.VUInstallationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Venice Unleashed");
				//Configuration.VUInstallationDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "VeniceUnleashed");

			if (!Directory.Exists(Configuration.Bf3DocumentsDirectory))
				Directory.CreateDirectory(Configuration.Bf3DocumentsDirectory);

			if (!Directory.Exists(Configuration.AdminDirectory))
				Directory.CreateDirectory(Configuration.AdminDirectory);

			if (!Directory.Exists(Configuration.ModsDirectory))
				Directory.CreateDirectory(Configuration.ModsDirectory);

			if (!File.Exists(Configuration.ServerKeyFilePath))
			{
				var result = MessageBox.Show($"Server.key file was not found at {Configuration.Bf3DocumentsDirectory}, you won't be able to run a server without a key", "Server key not found");
			}

			if (!File.Exists(Configuration.MapListFilePath))
				File.Create(Configuration.MapListFilePath);

			if (!File.Exists(Configuration.ModListFilePath))
				File.Create(Configuration.ModListFilePath);

			if (!File.Exists(Configuration.StartupFilePath))
				File.Create(Configuration.StartupFilePath);

			if (!File.Exists(Configuration.BanListFilePath))
				File.Create(Configuration.BanListFilePath);
		}
	}
}
