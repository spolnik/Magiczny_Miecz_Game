using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MagicznyMiecz.GUI.Converters
{
    public class NumberColorConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (int)value;

            switch (number)
            {
                case 0:
                    return new SolidColorBrush { Color = Colors.Red };
                case 1:
                    return new SolidColorBrush { Color = Colors.Blue };
                case 2:
                    return new SolidColorBrush { Color = Colors.Green };
                case 3:
                    return new SolidColorBrush { Color = Colors.Yellow };
                default:
                    throw new ArgumentOutOfRangeException("PlayerNo");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}