using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VULauncher.Commands;

namespace VULauncher.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for CreatePresetDialog.xaml
    /// </summary>
    public partial class CreatePresetDialog : Window
    {
        private RelayCommand _okCommand;

        public RelayCommand OkCommand
        {
            get => _okCommand ??= new RelayCommand(o => OnOkButtonClicked(), o => CanClickOk);
        }

        public CreatePresetDialog(Window owner, string watermarkText = null)
        {
            this.Owner = owner;
            InitializeComponent();
            //this.watermarkTextBox.Watermark = $"e.g. '{watermarkText}'" ?? "no_watermark_set";
            this.Title = $"e.g. '{watermarkText}'" ?? "no_watermark_set";
            this.watermarkTextBox.Focus();
        }


        public bool CanClickOk // TODO: Doesnt work for some reason
        {
            get => !string.IsNullOrWhiteSpace(PresetNameTextBoxText);
        }

        public string PresetNameTextBoxText { get; set; }

        public void OnOkButtonClicked()
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
