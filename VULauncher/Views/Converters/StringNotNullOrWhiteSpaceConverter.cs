using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace VULauncher.Views.Converters
{
    public class StringNotNullOrWhiteSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return false;

            var str = (string)value;

            return !string.IsNullOrWhiteSpace(str);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
