

namespace TI.Utilities.Collections.General
{
    /// <summary>
    /// The type of <see cref="Heap{T}"/> to implemented.
    /// </summary>
    public enum HeapType
    {
        /// <summary>
        /// Makes the heap a Minimum-Heap - the smallest item is kept in the root of the <see cref="Heap{T}"/>.
        /// </summary>
        Minimum,

        /// <summary>
        /// Makes the heap a Maximum-Heap - the largest item is kept in the root of the <see cref="Heap{T}"/>.
        /// </summary>
        Maximum
    }
}