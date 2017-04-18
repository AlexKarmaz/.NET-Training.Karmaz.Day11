using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.BinarySearch
{
    /// <summary>
    ///  This class provides custom generic binary search
    /// </summary>
    public static class BinarySearch
    {
        /// <summary>
        /// Finds index of element by using dichotomy method
        /// </summary>
        /// <typeparam name="T">Type of element</typeparam>
        /// <param name="array">The array in which the element is searched for</param>
        /// <param name="value">Seeking element</param>
        /// <param name="comparator">Comparison criterion</param>
        /// <returns>The index of the element to be searched, or if it is not present, returns -1.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int Search<T>(this T[] array, T value, Comparison<T> comparator)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (array.Length == 0)
                throw new ArgumentException("Array is empty");
            if (comparator == null)
                throw new ArgumentNullException(nameof(comparator));

            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int middle = left + (right - left) / 2;

                if (array[middle].Equals(value))
                    return middle;

                if (comparator(value, array[middle]) == 1)
                    left = middle + 1;
                else right = middle - 1;
            }

            return -1;
        }

        /// <summary>
        /// Finds index of element by using dichotomy method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array in which the element is searched for</param>
        /// <param name="value">Seeking element</param>
        /// <returns>The index of the element to be searched, or if it is not present, returns -1</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int Search<T>(this T[] array, T value)
            => Search(array, value, Comparer<T>.Default);

        /// <summary>
        /// Finds index of element by using dichotomy method
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">The array in which the element is searched for</param>
        /// <param name="value">Seeking element</param>
        /// <param name="comparer">The IComparer generic interface implementation to use when comparing elements, 
        /// or null to use the IComparable generic interface implementation of each element</param>
        /// <returns>The index of the element to be searched, or if it is not present, returns -1</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static int Search<T>(this T[] array, T value, IComparer<T> comparer)
            => Search(array, value, comparer.Compare);

    }
}
