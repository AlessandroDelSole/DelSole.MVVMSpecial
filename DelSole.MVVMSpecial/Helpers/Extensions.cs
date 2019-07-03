using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;

namespace DelSole.MVVMSpecial.Helpers
{
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
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value, string culture)
        {
            string originalString = value.ToString().ToLower();

            return new CultureInfo(culture).TextInfo.ToTitleCase(originalString);
        }
    }
}
