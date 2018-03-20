using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SsdCacher.Code.ValueConverters
{
    [ValueConversion(typeof(bool), typeof(string))]
    public class CachedLabelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return "FAST";
            }
            else
            {
                return "SLOW";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
