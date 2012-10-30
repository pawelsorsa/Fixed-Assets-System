using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using FixedAssetsApp.Concrete;

namespace FixedAssetsApp.Converters
{
    [ValueConversion(typeof(int), typeof(string))]
    public class PersonIDToNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return PersonMethods.GetNameAndSurnameByIdWebServiceMethod((int)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return true;
        }
    }
}
