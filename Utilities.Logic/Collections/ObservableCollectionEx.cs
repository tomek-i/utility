using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Threading;

namespace TI.Utilities.Collections
{
    public class ObservableCollectionEx<T> : ObservableCollection<T>
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="ObservableCollectionEx{T}" /> class.
        /// </summary>
        public ObservableCollectionEx()
        {
        }

        ///
        /// Initializes a new instance of the
        ///  class.
        ///
        ///The collection.
        public ObservableCollectionEx(IEnumerable<T> collection) : this()
        {
            this.AddRange(collection);
        }

        #endregion

        #region Events

        /// <summary>
        /// Source: New Things I Learned
        /// Title: Have worker thread update ObservableCollection that is bound to a ListCollectionView
        /// http://geekswithblogs.net/NewThingsILearned/archive/2008/01/16/have-worker-thread-update-observablecollection-that-is-bound-to-a.aspx
        /// Note: Improved for clarity and the following of proper coding standards.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            // Use BlockReentrancy
            using (BlockReentrancy())
            {
                var eventHandler = CollectionChanged;
                if (eventHandler == null) return;

                // Only proceed if handler exists.
                Delegate[] delegates = eventHandler.GetInvocationList();

                // Walk through invocation list.
                foreach (var @delegate in delegates)
                {
                    var handler = (NotifyCollectionChangedEventHandler)@delegate;
                    var currentDispatcher = handler.Target as DispatcherObject;

                    // If the subscriber is a DispatcherObject and different thread.
                    if ((currentDispatcher != null) && (!currentDispatcher.CheckAccess()))
                {
                        // Invoke handler in the target dispatcher's thread.
                        currentDispatcher.Dispatcher.Invoke(
                            DispatcherPriority.DataBind, handler, this, e);
                    }
 
                else
                {
                        // Execute as-is
                        handler(this, e);
                    }
                }
            }
        }

        /// <summary>
        /// Overridden NotifyCollectionChangedEventHandler event.
        /// </summary>
        public override event NotifyCollectionChangedEventHandler CollectionChanged;

        #endregion


        public void Apply(Action<T> predicate)
        {
            foreach (var item in this.Items)
            {
                predicate(item);
            }
        }

        public void SynchCollection(IEnumerable<T> collection)
        {
            if (collection == null) return;
            var list = collection.ToList();
            AddRange(list.Where(p => Items.IndexOf(p) == -1));
            RemoveRange(Items.Where(p => list.IndexOf(p) == -1));
        }

        public void SynchCollection(IList<T> collection, bool canSort = false)
        {
            SynchCollection(collection.AsEnumerable());
            if (!canSort) return;

            for (int i = 0; i < collection.Count; i++)
            {
                int index = Items.IndexOf(collection[i]);
                if (index == i) continue;

                Move(index, i);
            }
        }

        public void AddRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }

        public void RemoveRange(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Items.Remove(item);
            }
        }
    }
}