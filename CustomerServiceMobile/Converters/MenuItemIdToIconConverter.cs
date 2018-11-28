using CustomerServiceMobile.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace CustomerServiceMobile.Converters
{
    public class MenuItemIdToIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var type = (MenuItemType)value;

            switch (type)
            {
                case MenuItemType.List:
                    return "list.png";
                case MenuItemType.Exit:
                    return "exit.png";
                default:
                    return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
