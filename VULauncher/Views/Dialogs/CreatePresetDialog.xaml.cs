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
            get { return _okCommand ??= new RelayCommand(o => OnOkButtonClicked(), o => CanClickOk); }
        }

        public CreatePresetDialog()
        {
            InitializeComponent();
        }

        public bool CanClickOk // TODO: Doesnt work for some reason
        {
            get => !string.IsNullOrWhiteSpace(PresetNameTextBoxText);
        }

        public string PresetNameTextBoxText { get; set; }
        //{
            //get { return (string) GetValue(PresetNameTextBoxTextProperty); }
            //set
            //{
            //    SetValue(PresetNameTextBoxTextProperty, value);
            //}
        //}

        //// Using a DependencyProperty as the backing store for SelectedValuePath.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PresetNameTextBoxTextProperty =
        //    DependencyProperty.Register("PresetNameTextBoxText", typeof(string), typeof(CreatePresetDialog), new UIPropertyMetadata(""));


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
