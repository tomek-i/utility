using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// An OddEvenTransport sorter.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\OddEvenTransportSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\OddEvenTransportSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class OddEvenTransportSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            for (var i = 0; i < list.Count / 2; ++i)
            {
                for (var j = 0; j + 1 < list.Count; j += 2)
                {
                    if (comparer.Compare(list[j], list[j + 1]) > 0)
                    {
                        Swap(list, j, j + 1);
                    }
                }

                for (var j = 1; j + 1 < list.Count; j += 2)
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
