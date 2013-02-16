using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MagicznyMiecz.GUI.Converters
{
    public class LifeToForegroundConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lifes = (int) value;

            return lifes == 1 ? new SolidColorBrush(Colors.Red) : new SolidColorBrush(Colors.GhostWhite);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}