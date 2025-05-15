using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace bank_demo.Services
{
    public class NullOrEmptyToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var text = value as string;
            return string.IsNullOrWhiteSpace(text) ? Colors.Gray : Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
