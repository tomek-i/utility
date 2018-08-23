using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI.Utilities.Sorting
{


    /// <summary>
    /// A Bubble Sorter.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    public sealed class BubbleSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            for (var i = list.Count - 1; i >= 0; i--)
            {
                for (var j = 0; j < i; j++)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        Swap(list, j, j + 1);
                    }
                }
            }
        }

        #endregion
    }
}
