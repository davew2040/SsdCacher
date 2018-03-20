using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using SsdCacher.Code.ViewModels;

namespace SsdCacher.Code.ValueConverters
{
    public class CanCacheConverter : IMultiValueConverter
    {
        private const int IsBusyIndex = 0;
        private const int SelectedGameEntryIndex = 1;
        private const int SelectedGameIsCachedIndex = 2;

        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == DependencyProperty.UnsetValue
                || values[1] == DependencyProperty.UnsetValue
                || values[2] == DependencyProperty.UnsetValue)
            {
                return false;
            }

            bool isBusy = (bool)values[IsBusyIndex];
            GameEntry selectedGameEntry = (GameEntry)values[SelectedGameEntryIndex];
            bool entryIsCached = (bool)values[SelectedGameIsCachedIndex];

            return !isBusy && selectedGameEntry != null && !entryIsCached;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
