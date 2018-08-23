using System;
using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// The base class for all sorters.
    /// </summary>
    /// <typeparam name="T">The type of element to be sorted.</typeparam>
    public abstract class Sorter<T> : ISorter<T>
    {
        /// <inheritdoc />
        public void Sort(IList<T> list)
        {
            Sort(list, SortOrder.Ascending);
        }
        /// <inheritdoc />
        public abstract void Sort(IList<T> list, SortOrder order);

        ///<summary>
        /// Validates <paramref name="sortOrder" /> variable that it has a valid value
        ///</summary>
        ///<param name="sortOrder"></param>
        ///<exception cref="ArgumentOutOfRangeException"></exception>
        public static void ValidateSortOrder(SortOrder sortOrder)
        {
            if ((sortOrder != SortOrder.Ascending) && (sortOrder != SortOrder.Descending))
            {
                throw new ArgumentOutOfRangeException("sortOrder");
            }
        }
    }
}
