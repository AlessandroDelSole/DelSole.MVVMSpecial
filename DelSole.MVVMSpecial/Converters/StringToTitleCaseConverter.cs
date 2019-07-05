#pragma warning disable CS1591

using System;
using System.Globalization;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Makes uppercase the first letter of each word in a string
    /// </summary>
    public class StringToTitleCaseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string originalString = value.ToString().ToLower();

            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(originalString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
