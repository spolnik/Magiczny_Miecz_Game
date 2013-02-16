using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MagicznyMiecz.GUI.Converters
{
    public class BoolVisibilityConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (bool) value;

            return visibility ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var visibility = (Visibility) value;

            return visibility == Visibility.Visible;
        }

        #endregion
    }
}