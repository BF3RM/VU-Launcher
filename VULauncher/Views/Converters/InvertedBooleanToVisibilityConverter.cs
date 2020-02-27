using System.Windows;

namespace VULauncher.Views.Converters
{
    public sealed class InvertedBooleanToVisibilityConverter : BooleanConverter<Visibility>
    {
        public InvertedBooleanToVisibilityConverter() :
            base(Visibility.Collapsed, Visibility.Visible)
        {
        }
    }
}
