using System;
using System.Windows;
using System.Windows.Data;

namespace VULauncher.Views.Converters
{
    public sealed class EnumToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (parameter == null || value == null)
                return DependencyProperty.UnsetValue;

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            if (parameter.GetType() != value.GetType())
            {
                return DependencyProperty.UnsetValue;
            }

            return parameter.Equals(value) ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return parameter;
        }
    }
}
