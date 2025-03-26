using System.Globalization;
using Avalonia.Data.Converters;

namespace RapidDeskToolkit.UIPackage.Converters;

public class StringToFirstLetterConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string str)
        {
            return str.Length > 0 ? str[0].ToString().ToUpper() : string.Empty;
        }

        return string.Empty;
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
