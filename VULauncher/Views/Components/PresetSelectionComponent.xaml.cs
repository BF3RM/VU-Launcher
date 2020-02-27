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
    /// Interaction logic for PresetSelectionComponent.xaml
    /// </summary>
    public partial class PresetSelectionComponent : UserControl
    {
        public PresetSelectionComponent()
        {
            InitializeComponent();
        }

        public IEnumerable ComboBoxItemsSource
        {
            get { return (IEnumerable)GetValue(ComboBoxItemsSourceProperty); }
            set { SetValue(ComboBoxItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ComboBoxItemsSourceProperty =
            DependencyProperty.Register("ComboBoxItemsSource", typeof(IEnumerable), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));

        public object ComboBoxSelectedItem
        {
            get { return (object)GetValue(ComboBoxSelectedItemProperty); }
            set { SetValue(ComboBoxSelectedItemProperty, value); }
        }

        public static readonly DependencyProperty ComboBoxSelectedItemProperty =
            DependencyProperty.Register("ComboBoxSelectedItem", typeof(object), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));

        public RelayCommand ChangeTabCommand
        {
            get { return (RelayCommand)GetValue(ChangeTabCommandProperty); }
            set { SetValue(ChangeTabCommandProperty, value); }
        }

        public static readonly DependencyProperty ChangeTabCommandProperty =
            DependencyProperty.Register("ChangeTabCommand", typeof(RelayCommand), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));

        public object ChangeTabCommandParameter
        {
            get { return (object)GetValue(ChangeTabCommandParameterProperty); }
            set { SetValue(ChangeTabCommandParameterProperty, value); }
        }

        public static readonly DependencyProperty ChangeTabCommandParameterProperty =
            DependencyProperty.Register("ChangeTabCommandParameter", typeof(object), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));

        public bool ShowChangeTabButton
        {
            get { return (bool)GetValue(ShowChangeTabButtonProperty); }
            set { SetValue(ShowChangeTabButtonProperty, value); }
        }

        public static readonly DependencyProperty ShowChangeTabButtonProperty =
            DependencyProperty.Register("ShowChangeTabButton", typeof(bool), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));

        public string DescriptionText
        {
            get { return (string)GetValue(DescriptionTextProperty); }
            set { SetValue(DescriptionTextProperty, value); }
        }

        public static readonly DependencyProperty DescriptionTextProperty =
            DependencyProperty.Register("DescriptionText", typeof(string), typeof(PresetSelectionComponent), new UIPropertyMetadata(null));
    }
}
