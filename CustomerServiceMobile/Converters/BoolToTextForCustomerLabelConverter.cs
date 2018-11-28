using System;
using System.Globalization;
using Xamarin.Forms;

namespace CustomerServiceMobile.Converters
{
    public class BoolToTextForCustomerLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = (bool)value;

            return boolValue ? "Add new customer" : "Update customer";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
