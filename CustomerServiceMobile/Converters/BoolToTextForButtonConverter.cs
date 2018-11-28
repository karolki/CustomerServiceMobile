using System;
using System.Globalization;
using Xamarin.Forms;

namespace CustomerServiceMobile.Converters
{
    public class BoolToTextForButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;

            return boolValue ? "ADD" : "UPDATE";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
