using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.Converters
{
    public class ZeroVisibilityConverter : IMultiValueConverter
    {
        #region Implementation of IMultiValueConverter

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var pure = (int)values[0];

                var total = (int)values[1];

                return total - pure > 0 ? Visibility.Visible : Visibility.Hidden;
            }
            catch (InvalidCastException)
            {
                return Visibility.Hidden;
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}