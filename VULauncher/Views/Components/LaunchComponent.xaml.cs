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
    /// Interaction logic for LaunchComponent.xaml
    /// </summary>
    public partial class LaunchComponent : UserControl
    {
        public LaunchComponent()
        {
            InitializeComponent();
        }

        public IEnumerable ComboBoxItemsSource
        {
            get => (IEnumerable)GetValue(ComboBoxItemsSourceProperty);
            set => SetValue(ComboBoxItemsSourceProperty, value);
        }

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable), typeof(LaunchComponent), new UIPropertyMetadata(null));

        public object ComboBoxSelectedItem
        {
            get => (object)GetValue(ComboBoxSelectedItemProperty);
            set => SetValue(ComboBoxSelectedItemProperty, value);
        }

        public static readonly DependencyProperty ComboBoxSelectedItemProperty =
            DependencyProperty.Register("ComboBoxSelectedItem", typeof(object), typeof(LaunchComponent), new UIPropertyMetadata(null));

        public RelayCommand StartPresetCommand
        {
            get => (RelayCommand)GetValue(StartPresetCommandProperty);
            set => SetValue(StartPresetCommandProperty, value);
        }

        public static readonly DependencyProperty StartPresetCommandProperty =
            DependencyProperty.Register("StartPresetCommand", typeof(RelayCommand), typeof(LaunchComponent), new UIPropertyMetadata(null));

        private void LaunchSplitButtonItem_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            LaunchSplitButton.IsOpen = false;
        }
    }
}
