using System;
using System.Globalization;
using System.Windows.Data;

namespace MagicznyMiecz.GUI.Converters
{
    public class LifeToFontSizeConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var lifes = (int)value;

            return lifes == 1 ? 14 : 11;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}