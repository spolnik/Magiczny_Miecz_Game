using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Data;
using MagicznyMiecz.Common.Core;

namespace MagicznyMiecz.GUI.Converters
{
    public class EnableToolTipConverter : IValueConverter
    {
        #region Implementation of IValueConverter

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var character = value as ICharacter;

            if (character == null) throw new ArgumentException("Converter value is not a character");

            return character.Items.Count > 0 ? Visibility.Visible : Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}