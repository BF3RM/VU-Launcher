using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using VULauncher.Commands;
using VULauncher.Models.Config;
using VULauncher.ViewModels.Common;

namespace VULauncher.ViewModels
{
	public class ConfigViewModel : ViewModel
	{
		private string _bf3DocumentsDirectory;
		private string _vuInstallationDirectory;

		public RelayCommand OpenBf3DocumentsDirectoryCommand { get; }
		public RelayCommand OpenVUInstallationDirectoryCommand { get; }

		public string BF3DocumentsDirectory
		{
			get => _bf3DocumentsDirectory;

			set
			{
				if (SetField(ref _bf3DocumentsDirectory, value))
				{
					Configuration.Bf3DocumentsDirectory = value;
				}
			}
		}
		
		public string VUInstallationDirectory
		{
			get => _vuInstallationDirectory;

			set
			{
				if (SetField(ref _vuInstallationDirectory, value))
				{
					Configuration.VUInstallationDirectory = value;
				}
			}
		}

		public ConfigViewModel()
		{
			_bf3DocumentsDirectory = Configuration.Bf3DocumentsDirectory;
			_vuInstallationDirectory = Configuration.VUInstallationDirectory;

			OpenBf3DocumentsDirectoryCommand = new RelayCommand(x => OpenBf3DocumentsDirectory(), x => true);
			OpenVUInstallationDirectoryCommand = new RelayCommand(x => OpenVUInstallationDirectory(), x => true);
		}

		private void OpenBf3DocumentsDirectory()
		{
			var newDir = SelectFolderFromDialog(BF3DocumentsDirectory);

			if (string.IsNullOrEmpty(newDir))
				return;

			BF3DocumentsDirectory = newDir;
		}

		private void OpenVUInstallationDirectory() 
		{
			var newDir = SelectFolderFromDialog(VUInstallationDirectory);

			if (string.IsNullOrEmpty(newDir))
				return;

			VUInstallationDirectory = newDir;
		}

		private string SelectFolderFromDialog(string initialDirectory)
		{
			CommonOpenFileDialog dialog = new CommonOpenFileDialog();
			dialog.InitialDirectory = initialDirectory;
			dialog.IsFolderPicker = true;

			if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
				return dialog.FileName;

			return null;
		}
	}
}
