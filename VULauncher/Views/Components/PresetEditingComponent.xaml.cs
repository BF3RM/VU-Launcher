using System;
using System.Collections;
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
using VULauncher.Commands;

namespace VULauncher.Views.Components
{
    /// <summary>
    /// Interaction logic for PresetEditingComponent.xaml
    /// </summary>
    public partial class PresetEditingComponent : UserControl
    {
        public PresetEditingComponent()
        {
            InitializeComponent();
        }

        public IEnumerable ComboBoxItemsSource
        {
            get => (IEnumerable)GetValue(ComboBoxItemsSourceProperty);
            set => SetValue(ComboBoxItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable), typeof(PresetEditingComponent), new UIPropertyMetadata(null));

        public object ComboBoxSelectedItem
        {
            get => (object)GetValue(ComboBoxSelectedItemProperty);
            set => SetValue(ComboBoxSelectedItemProperty, value);
        }

        public static readonly DependencyProperty ComboBoxSelectedItemProperty =
            DependencyProperty.Register("ComboBoxSelectedItem", typeof(object), typeof(PresetEditingComponent), new UIPropertyMetadata(null));

        public RelayCommand CreatePresetCommand
        {
            get => (RelayCommand)GetValue(CreatePresetCommandProperty);
            set => SetValue(CreatePresetCommandProperty, value);
        }

        public static readonly DependencyProperty CreatePresetCommandProperty =
            DependencyProperty.Register("CreatePresetCommand", typeof(RelayCommand), typeof(PresetEditingComponent), new UIPropertyMetadata(null));

        public RelayCommand DeletePresetCommand
        {
            get => (RelayCommand)GetValue(DeletePresetCommandProperty);
            set => SetValue(DeletePresetCommandProperty, value);
        }

        public static readonly DependencyProperty DeletePresetCommandProperty =
            DependencyProperty.Register("DeletePresetCommand", typeof(RelayCommand), typeof(PresetEditingComponent), new UIPropertyMetadata(null));

    }
}
