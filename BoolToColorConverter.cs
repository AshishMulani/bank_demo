using System.Globalization;
using Microsoft.Maui.Controls;

public class BoolToColorConverter : IValueConverter
{
    public string TrueColor { get; set; } = "Blue";
    public string FalseColor { get; set; } = "Gray";

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        bool flag = value is bool b && b;

        if (parameter is string param)
        {
            var parts = param.Split(';')
                             .Select(p => p.Split('='))
                             .ToDictionary(p => p[0].Trim(), p => p[1].Trim());

            if (parts.TryGetValue("True", out string trueColor))
                TrueColor = trueColor;

            if (parts.TryGetValue("False", out string falseColor))
                FalseColor = falseColor;
        }

        return Color.FromArgb(flag ? TrueColor : FalseColor);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotSupportedException();
}
