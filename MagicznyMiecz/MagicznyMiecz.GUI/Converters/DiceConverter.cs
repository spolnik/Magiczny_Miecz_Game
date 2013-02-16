using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MagicznyMiecz.GUI.Converters
{
    public class DiceConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) throw new ArgumentNullException("ConverterParameter");

            var dice = (int)value;
            var dot = int.Parse(parameter as string);

            switch (dice)
            {
                case 1:
                    if (dot == 3) return Visibility.Visible;
                    break;
                case 2:
                    if (dot == 0) return Visibility.Visible;
                    if (dot == 6) return Visibility.Visible;
                    break;
                case 3:
                    if (dot == 0) return Visibility.Visible;
                    if (dot == 3) return Visibility.Visible;
                    if (dot == 6) return Visibility.Visible;
                    break;
                case 4:
                    if (dot == 0) return Visibility.Visible;
                    if (dot == 2) return Visibility.Visible;
                    if (dot == 4) return Visibility.Visible;
                    if (dot == 6) return Visibility.Visible;
                    break;
                case 5:
                    if (dot == 0) return Visibility.Visible;
                    if (dot == 2) return Visibility.Visible;
                    if (dot == 3) return Visibility.Visible;
                    if (dot == 4) return Visibility.Visible;
                    if (dot == 6) return Visibility.Visible;
                    break;
                case 6:
                    if (dot == 0) return Visibility.Visible;
                    if (dot == 1) return Visibility.Visible;
                    if (dot == 2) return Visibility.Visible;
                    if (dot == 4) return Visibility.Visible;
                    if (dot == 5) return Visibility.Visible;
                    if (dot == 6) return Visibility.Visible;
                    break;
            }

            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}