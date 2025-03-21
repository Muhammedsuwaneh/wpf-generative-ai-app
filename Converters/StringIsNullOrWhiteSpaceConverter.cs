using System.Globalization;
using System.Windows.Data;

namespace GenAI_ImageGenerator.Converters
{
    public class StringIsNullOrWhiteSpaceConverter : IValueConverter
    {
        public static readonly StringIsNullOrWhiteSpaceConverter Instance = new StringIsNullOrWhiteSpaceConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace(value as string);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
