using System.Collections.Generic;
using System.Collections.ObjectModel;

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
    }
}
