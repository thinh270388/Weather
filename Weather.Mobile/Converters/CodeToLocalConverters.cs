using System.Globalization;
using Weather.Models.Helpers;

namespace Weather.Mobile.Converters
{
    public class CodeToLocalConverters : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            try
            {
                if (value == null) return "Không có dữ liệu";
                return ConvertHelper.ConvertLocalWeather((int)value!);
            }
            catch (Exception)
            {
                return "Không có dữ liệu";
            }

        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
