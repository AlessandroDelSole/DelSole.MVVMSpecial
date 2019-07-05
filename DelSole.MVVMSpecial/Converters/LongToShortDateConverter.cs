#pragma warning disable CS1591

using System;
using System.Globalization;
using Xamarin.Forms;

namespace DelSole.MVVMSpecial.Converters
{
    /// <summary>
    /// Convert a long <seealso cref="DateTime"/> into its short representation
    /// </summary>
    public class LongToShortDateConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var currentStringDate = value.ToString();

                var realDate = DateTime.Parse(currentStringDate);

                if (realDate == DateTime.MinValue)
                    return "";

                string formattedDate = realDate.ToString("d");
                //if (formattedDate.Contains("."))
                //    return formattedDate.Replace('.', '/');
                //else
                return formattedDate;

                //return realDate.ToString("d", new CultureInfo(CultureInfo.DefaultThreadCurrentCulture.Name));
            }
            catch (Exception)
            {
                // There is a bug in Mono that occurs with some dates in the year 1948. 
                // See also https://forums.xamarin.com/discussion/107311/datetime-tryparseexact-bug

                // This is the full exception detail:
                /* System.ArgumentOutOfRangeException: 
                 * Year, Month, and Day parameters describe an un-representable DateTime." 
                 * and happens here "System.DateTime.DateToTicks (System.Int32 year, System.Int32 month, System.Int32 day) [0x0006c] 
                 * in /Library/Frameworks/Xamarin.iOS.framework/Versions/11.3.0.47/src/mono/mcs/class/referencesource/mscorlib/system/datetime.cs". */

                // To address this issue, in case of an exception, we first split the string and check if the first item (the year)
                // is 1948 and then we create a DateTime manually
                var split = value.ToString().Split('-', '/', ' ');

                if (split[0] == "1948")
                {
                    var handParsedDate = new DateTime(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]));

                    string formattedDate = handParsedDate.ToString("d");

                    //if (formattedDate.Contains("."))
                    //    return formattedDate.Replace('.', '/');
                    //else
                    return formattedDate;

                }
                else
                {
                    return DateTime.MinValue.ToString("d");
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
