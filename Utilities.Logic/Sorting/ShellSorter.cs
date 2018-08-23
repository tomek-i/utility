﻿using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// A sorter that implements the Shell Sort algorithm.
    /// </summary>
    /// <typeparam name="T">The type of the elements to be sorted.</typeparam>
    /// <example>
    /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Sorting\ShellSorterExamples.cs" region="Sort" lang="cs" title="The following example shows how to use the Sort method."/>
    /// <code source="..\..\Source\Examples\ExampleLibraryVB\Sorting\ShellSorterExamples.vb" region="Sort" lang="vbnet" title="The following example shows how to use the Sort method."/>
    /// </example>
    public sealed class ShellSorter<T> : ComparisonSorter<T>
    {
        #region Sorter<T> Members

        /// <inheritdoc />
        protected override void SortItems(IList<T> list, IComparer<T> comparer)
        {
            var delta = list.Count;

            do
            {
                delta = 1 + (delta / 3);

                for (var i = 0; i < delta; i++)
                {
                    var counter = delta + i;

                    // Insertion sort the segments
                    while (counter < list.Count)
                    {
                        var start = counter;
                        var tmp = list[start];

                        while (start != i)
                        {
                            if (comparer.Compare(list[start - delta], tmp) > 0)
                            {
                                list[start] = list[start - delta];
                                start -= delta;
                            }
                            else
                            {
                                break;
                            }
                        }

                        list[start] = tmp;
                        counter += delta;
                    }
                }
            }
            while (delta > 1);
        }

        #endregion
    }
}
