using System.Windows.Controls;

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
            //int max_lines = 1000;
            //if (textBox.LineCount > max_lines)
            //{
            //    textBox.Text = textBox.Text.Remove(0, textBox.GetLineLength(500));
            //}

            //textBox.SelectionStart = textBox.Text.Length;
            //textBox.ScrollToEnd();
        }
    }
}
