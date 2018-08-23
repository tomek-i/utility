using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// A Shaker Sorter.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\ShakerSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\ShakerSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class ShakerSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            var i = 0;
            var k = list.Count - 1;

            while (i < k)
            {
                var minimum = i;
                var maximum = i;

                for (var j = i + 1; j <= k; j++)
                {
                    if (comparer.Compare(list[j], list[minimum]) < 0)
                    {
                        minimum = j;
                    }
                    if (comparer.Compare(list[j], list[maximum]) > 0)
                    {
                        maximum = j;
                    }
                }

                Swap(list, minimum, i);

                if (maximum == i)
                {
                    Swap(list, minimum, k);
                }
                else
                {
                    Swap(list, maximum, k);
                }

                i++;
                k--;
            }
        }

        #endregion
    }
}
