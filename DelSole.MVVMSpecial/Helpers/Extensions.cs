using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DelSole.MVVMSpecial.Helpers
{
    /// <summary>
    /// Defines helper extension methods
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Return an <seealso cref="ObservableCollection{T}"/> from any <seealso cref="IEnumerable{T}"/> set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"></param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            if (collection != null)
                return new ObservableCollection<T>(collection);
            else
                return null;
        }

        /// <summary>
        /// Capitalize the first letter of each word in a string
        /// </summary>
        /// <param name="value">The string to be converted</param>
        /// <param name="culture">The culture representation in the ISO format (e.g. en-US or en)</param>
        /// <returns><seealso cref="string"/></returns>
        public static string ToTitleCase(this string value, string culture)
        {
            string originalString = value.ToString().ToLower();

            return new CultureInfo(culture).TextInfo.ToTitleCase(originalString);
        }
    }
}
