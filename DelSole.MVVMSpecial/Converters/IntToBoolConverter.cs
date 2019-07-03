using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
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
