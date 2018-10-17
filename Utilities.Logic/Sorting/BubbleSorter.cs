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
            for (var iteration = list.Count - 1; iteration >= 0; iteration--)
            {
                for (var currentIndex = 0; currentIndex < iteration; currentIndex++)
                {
                    if (comparer.Compare(list[currentIndex], list[currentIndex + 1]) > 0)
                    {
                        Swap(list, currentIndex, currentIndex + 1);
                    }
                }
            }
        }

        #endregion
    }
}
