using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace VULauncher.Views.Converters
{
    public sealed class InvertedEnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null || value == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            if (parameter.GetType() != value.GetType())
            {
                return DependencyProperty.UnsetValue;
            }

            return parameter.Equals(value) ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter;
        }
    }
}
