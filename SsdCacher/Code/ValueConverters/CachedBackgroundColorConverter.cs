using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace SsdCacher.Code.ValueConverters
{
    [ValueConversion(typeof(bool), typeof(Brush))]
    public class CachedBackgroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return new SolidColorBrush(Colors.LightGreen);
            }
            else
            {
                return new SolidColorBrush(Colors.LightSalmon);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
