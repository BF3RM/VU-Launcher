using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Microsoft.Win32;

namespace VULauncher.ViewModels.Common
{
	public static class WebsiteUtil
	{
		public static void OpenWebSite(string websitePath)
		{
			string browserPath = GetBrowserPath();
			if (browserPath == string.Empty)
				browserPath = "iexplore";
			Process process = new Process();
			process.StartInfo = new ProcessStartInfo(browserPath);
			process.StartInfo.Arguments = "\"" + websitePath + "\"";
			process.Start();
		}

		private static string GetBrowserPath()
		{
			string browser = string.Empty;

			try
			{
				// try location of default browser path in XP
				var key = Registry.ClassesRoot.OpenSubKey(@"HTTP\shell\open\command", false);

				// try location of default browser path in Vista
				if (key == null)
				{
					key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http", false); ;
				}

				if (key != null)
				{
					//trim off quotes
					browser = key.GetValue(null).ToString().ToLower().Replace("\"", "");
					if (!browser.EndsWith("exe"))
					{
						//get rid of everything after the ".exe"
						browser = browser.Substring(0, browser.LastIndexOf(".exe") + 4);
					}

					key.Close();
				}
			}
			catch
			{
				return string.Empty;
			}

			return browser;
		}
    }
}
