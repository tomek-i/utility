using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// An interface for a Sorter.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    public interface ISorter<T>
    {
        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        void Sort(IList<T> list);

        /// <summary>
        /// Sorts the specified list.
        /// </summary>
        /// <param name="list">The list to sort.</param>
        /// <param name="order">The order in which to sort the list.</param>
        void Sort(IList<T> list, SortOrder order);
    }
}
