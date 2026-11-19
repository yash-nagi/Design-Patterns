using System.Globalization;

namespace to_do_list.Converters;

public class CompletedTextConverter : IValueConverter
{
    public object Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        return value is true
            ? TextDecorations.Strikethrough
            : TextDecorations.None;
    }

    public object ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}