using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using VULauncher.ViewModels.Items.Common;
using VULauncher.Views.Common;

namespace VULauncher.Views.Converters
{
    public class ChangePresetTabParametersMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[1] == DependencyProperty.UnsetValue)
                return null;

            return new ChangePresetTabParameters() { TabIndex = (int)values[0], SelectedPresetId = ((PresetItem)values[1]).Id };
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
