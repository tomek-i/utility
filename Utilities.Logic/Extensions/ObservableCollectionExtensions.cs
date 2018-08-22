using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace TI.Utilities.Extensions
{

    public static class ObservableCollectionExtensions
    {
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="collection">The collection.</param>
        public static void AddRange<T>(this IList<T> items, IEnumerable<T> collection)
        {
            // Add range to local items
            collection.Apply(items.Add);
        }
        /// <summary>
        /// Synches the collection items to the target collection items.
        /// This does not observe sort order.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="collection">The collection.</param>
        public static void SynchCollection<T>(this IList<T> items, IEnumerable<T> collection)
        {
            // Evaluate
            if (collection == null) return;

            // Make a list
            var list = collection.ToList();

            // Add items not in FilteredViewItems that are in list
            items.AddRange(list.Where(p => items.IndexOf(p) == -1).ToList());

            // Remove items from FilteredViewItems not in list
            items.RemoveRange(items.Where(p => list.IndexOf(p) == -1).ToList());
        }
        /// <summary>
        /// Synches the collection items to the target collection items.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="canSort">if set to <c>true</c> [can sort].</param>
        public static void SynchCollection<T>(this ObservableCollection<T> items,
            IList<T> collection, bool canSort = false)
        {
            // Synch collection
            SynchCollection(items, collection.AsEnumerable());

            // Sort collection
            if (!canSort) return;

            // Update indexes as needed
            for (var i = 0; i < collection.Count; i++)
            {
                // Index of new location
                int index = items.IndexOf(collection[i]);
                if (index == i) continue;

                // Move item to new index if it has changed.
                items.Move(index, i);
            }
        }
        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="collection">The collection.</param>
        public static void RemoveRange<T>(this IList<T> items, IEnumerable<T> collection)
        {
            // Remove range from local items
            collection.Apply(p => items.Remove(p));
        }
        /// <summary>
        /// Applies the specified changes to the collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <param name="predicate">The predicate.</param>
        public static void Apply<T>(this IEnumerable<T> items, Action<T> predicate)
        {
            foreach (var item in items)
            {
                predicate(item);
            }
        }
    }
}