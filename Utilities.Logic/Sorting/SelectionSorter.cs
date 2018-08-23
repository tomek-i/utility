using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// A sorter implementing the Selection Sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\SelectionSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\SelectionSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class SelectionSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            for (var i = 0; i < list.Count; i++)
            {
                var minIndex = i;

                // Find the smallest item in what's left of the array
                for (var j = i + 1; j < list.Count; j++)
                {
                    if (comparer.Compare(list[j], list[minIndex]) < 0)
                    {
                        minIndex = j;
                    }
                }

                // Swap the minimum and the current item at index i.
                Swap(list, i, minIndex);
            }
        }

        #endregion
    }
}
