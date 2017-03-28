using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UltraTT.View.Game
{
    public class BorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tuple = (Tuple<Func<object, bool>, object>)parameter;
            var ok = tuple.Item1.Invoke(tuple.Item2);
            return new Thickness((bool)value && ok ? 2 : 0);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }
    }
}