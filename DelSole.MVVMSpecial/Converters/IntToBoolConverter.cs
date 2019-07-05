#pragma warning disable CS1591

using System;
using System.Globalization;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Convert an <seealso cref="int"/> into <seealso cref="bool"/>. 0 means false, all others mean true
    /// </summary>
    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int originalValue = (int)value;

            if (parameter == null)
            {
                switch (originalValue)
                {
                    case 0:
                        return false;
                    default:
                        return true;
                }
            }
            else
            {
                switch (originalValue)
                {
                    case 1:
                        return false;
                    default:
                        return true;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
