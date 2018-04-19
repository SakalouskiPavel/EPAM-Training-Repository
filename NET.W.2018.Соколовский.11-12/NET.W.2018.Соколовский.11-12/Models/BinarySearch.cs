using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2018.Соколовский._11_12.Models
{
    public static class BinarySearch 
    {
        /// <summary>
        /// Find element in collection by binary search method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection"> Input collection.</param>
        /// <param name="element"> Wanted element.</param>
        /// <param name="comparer"></param>
        /// <returns></returns>
        public static int Find<T>(this IEnumerable<T> collection, T element, IComparer<T> comparer)
        {
            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException(nameof(collection));
            }

            if (ReferenceEquals(element, null))
            {
                throw new ArgumentNullException(nameof(element));
            }

            if (ReferenceEquals(comparer, null))
            {
                comparer = Comparer<T>.Default;
            }

            int left = 0, right = collection.Count() - 1;
            int mid = right / 2;

            while (left <= right)
            {
                int result = comparer.Compare(collection.Skip(mid).First(), element);
                if (result == 0)
                {
                    return mid;
                }                    
                else if (result < 0)
                {
                    left = mid + 1;
                    mid = (left + right) / 2;
                }
                else if (true)
                {
                    right = mid - 1;
                    mid = (left + right) / 2;
                }
            }

            return -1;
        }

        public static int Find<T>(this IEnumerable<T> collection, T element)
        {
            var comparer = Comparer<T>.Default;
            return Find<T>(collection, element, comparer);
        }
    }
}
