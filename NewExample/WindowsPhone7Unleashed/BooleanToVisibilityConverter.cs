
using System.Windows;
using System.Windows.Data;
using System;
using System.Globalization;
namespace NewExample.WindowsPhone7Unleashed
{
    public class BooleanToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            string paramValue = (string)parameter;

            if (value == null || (bool)value)
            {
                return paramValue == "Collapsed"
                    ? Visibility.Collapsed : Visibility.Visible;
            }

            return paramValue == "Collapsed"
                ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            string paramValue = (string)parameter;
            if (value == null || (Visibility)value == Visibility.Visible)
            {
                return paramValue != "Collapsed";
            }

            return paramValue == "Collapsed";
        }
    }
}
