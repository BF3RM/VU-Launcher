using System;
using System.Collections.Generic;
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
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int max_lines = 1000;
            if (textBox.LineCount > max_lines)
            {
                textBox.Text = textBox.Text.Remove(0, textBox.GetLineLength(500));
            }

            textBox.SelectionStart = textBox.Text.Length;
            textBox.ScrollToEnd();
        }
    }
}
