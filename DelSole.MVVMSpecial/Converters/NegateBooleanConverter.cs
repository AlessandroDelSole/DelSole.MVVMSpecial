#pragma warning disable CS1591

using System;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Convert a bool value into its negation (e.g. from true to false)
    /// </summary>
    public class NegateBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
