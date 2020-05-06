using System;
using System.Windows;
using System.Windows.Controls;
using VULauncher.Util;
using VULauncher.ViewModels.Common;
using VULauncher.Views.Controls.Consoles;
using Xceed.Wpf.AvalonDock.Layout;

namespace VULauncher.ViewModels.ConsoleViewModels
{
    public class VuConsoleViewModel : DockableDocumentViewModel
    {
	    public ProcessUtils GameProcess { get; set; }

        public VuConsoleViewModel(string consoleName)
        {
            Title = consoleName;
            GameProcess = new ProcessUtils();
        }

        public string _textBoxContent = "";
        public string TextBoxContent
        {
            get => _textBoxContent;
            set => SetField(ref _textBoxContent, value);
        }

        public void WriteLog(string text)
        {
            if (text.Length > 0)
            {
                if (TextBoxContent.Length > 0) {
                    TextBoxContent += Environment.NewLine + text;
                }
                else
                {
                    TextBoxContent += text;
                }
            }
        }
    }
}
