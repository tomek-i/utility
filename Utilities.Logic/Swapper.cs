using System.Collections.Generic;

namespace TI.Utilities
{
    /// <summary>
    /// Utility class for swapping values
    /// </summary>
    internal static class Swapper
    {

        /// <summary>
        /// Swaps items in the specified positions in the given list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">The list.</param>
        /// <param name="pos1">The position of the first item.</param>
        /// <param name="pos2">The position of the second item.</param>
        internal static void Swap<T>(IList<T> list, int pos1, int pos2)
        {
            var tmp = list[pos1];
            list[pos1] = list[pos2];
            list[pos2] = tmp;
        }
    }
}