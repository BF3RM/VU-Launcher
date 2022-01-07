using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace VULauncher.Views.Controls.Consoles
{
    /// <summary>
    /// Interaction logic for VuConsoleControl.xaml
    /// </summary>
    public partial class VuConsoleControl : UserControl
    {
        public VuConsoleControl()
        {
            InitializeComponent();

            using (StreamReader s = new StreamReader(@"C:\Repos\VULauncher\VULauncher\Views\Controls\Consoles\ConsoleOutputHighlighting.xshd"))
            {
                using (XmlTextReader reader = new XmlTextReader(s))
                {
                    textEditor.SyntaxHighlighting = HighlightingLoader.Load(
                            reader,
                            HighlightingManager.Instance);
                }
            }
        }

        private void TextBox_OnTextChanged(object? sender, EventArgs e)
        {
            textEditor.SelectionStart = textEditor.Text.Length;
            textEditor.ScrollToEnd();
        }
    }
}
