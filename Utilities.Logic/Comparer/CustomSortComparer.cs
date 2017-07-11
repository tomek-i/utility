using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace TIUtilities.Logic
{
    /// <summary>
    /// Customer Sort Comparer.
    /// Original Source:
    /// http://blogs.msdn.com/b/jgoldb/archive/2008/08/28/improving-microsoft-datagrid-ctp-sorting-performance-part-2.aspx
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class CustomSortComparer<T> : IComparer<T>
    {
        #region Members

        /// <summary>
        /// A two argument delegate for comparing two objects.
        /// </summary>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns></returns>
        protected delegate int TwoArgDelegate(T arg1, T arg2);

        /// <summary>
        /// A two argument delegate instance.
        /// </summary>
        private TwoArgDelegate _myCompare;

        #endregion

        #region Methods

        /// <summary>
        /// Sorts the specified target collection.
        /// </summary>
        /// <param name="targetCollection">The target collection.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
        public void Sort(ObservableCollection<T> targetCollection, string propertyName,
            ListSortDirection direction)
        {
            // Sort comparer
            var sortComparer = new InternalSorting(propertyName, direction);

            // Sort
            var sortedCollection = targetCollection.OrderBy(x => x, sortComparer).ToList();

            // Synch
            targetCollection.SynchCollection(sortedCollection, true);
        }

        /// <summary>
        /// Performs custom sorting operation.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="direction">The direction.</param>
        internal void CustomSort(string propertyName, ListSortDirection direction)
        {
            int dir = (direction == ListSortDirection.Ascending) ? 1 : -1;

            // Set a delegate to be called by IComparer.Compare
            _myCompare = (a, b) => ReflectionCompareTo(a, b, propertyName) * dir;
        }

        /// <summary>
        /// Custom compareTo function to compare 2 objects derived using Reflection.
        /// If an aliasProperty is provided, the sort is performed on that property
        /// instead.
        /// This is ideal for columns with data types that need to be sorted by another
        /// data type.
        /// i.e. Images that need value associations, or strings with numeric entries.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        private static int ReflectionCompareTo(object a, object b, String propertyName)
        {
            // Get property value for "a"
            PropertyInfo aPropInfo = a.GetType().GetProperty(propertyName);
            var aValue = aPropInfo.GetValue(a, null);
            if (aValue == null) return 0;

            // Get property value for "b"
            PropertyInfo bPropInfo = b.GetType().GetProperty(propertyName);
            var bValue = bPropInfo.GetValue(b, null);
            if (bValue == null) return 0;

            // CompareTo method
            MethodInfo compareToMethod =
                aPropInfo.PropertyType.GetMethod("CompareTo", new[] { aPropInfo.PropertyType });
            if (compareToMethod == null) return 0;

            // Get result
            var compareResult = compareToMethod.Invoke(aValue, new[] { bValue });
            return Convert.ToInt32(compareResult);
        }

        #endregion

        #region ICompare

        /// <summary>
        /// Compares two objects and returns a value indicating whether one is less 
        /// than, equal to, or greater than the other.
        /// </summary>
        /// <param name="x">The first object to compare.</param>
        /// <param name="y">The second object to compare.</param>
        /// <returns>
        /// Value
        /// Condition
        /// Less than zero
        /// <paramref name="x" /> is less than <paramref name="y" />.
        /// Zero
        /// <paramref name="x" /> equals <paramref name="y" />.
        /// Greater than zero
        /// <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(T x, T y)
        {
            return _myCompare(x, y);
        }

        #endregion

        #region InternalSorting

        /// <summary>
        /// Custom IComparer class to perform custom sorting.
        /// </summary>
        private class InternalSorting : CustomSortComparer<T>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="InternalSorting"/> class.
            /// </summary>
            /// <param name="propertyName">Name of the property.</param>
            /// <param name="direction">The direction.</param>
            public InternalSorting(string propertyName, ListSortDirection direction)
            {
                CustomSort(propertyName, direction);
            }
        }
        #endregion
    }

    }