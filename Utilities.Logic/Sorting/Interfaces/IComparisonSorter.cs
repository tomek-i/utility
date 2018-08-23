using System;
using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// An interface for sorters that make the use of Comparers or Comparisons.
    /// </summary>
    /// <typeparam name="T">The element type the sorter w</typeparam>
    public interface IComparisonSorter<T> : ISorter<T>
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparer">The comparer to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is a null reference.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference.</exception>
        void Sort(IList<T> list, IComparer<T> comparer);

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="comparison">The comparison to use.</param>
        /// <exception cref="ArgumentNullException"><paramref name="list"/> is a null reference.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference.</exception>
        void Sort(IList<T> list, Comparison<T> comparison);
    }
}
