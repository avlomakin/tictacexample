using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using UltraTT.Command;

namespace UltraTT.View.Game
{
    public class BorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //var command = (RelayCommand)parameter;
            //var ok = command.CanExecute()
            return new Thickness(2);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}