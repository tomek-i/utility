﻿using System;
using System.Collections.Generic;

namespace TI.Utilities.Sorting
{
    /// <summary>
    /// A comparer for comparing keys for the KeyValuePair class.
    /// </summary>
    /// <typeparam name="TKey">The key type.</typeparam>
    /// <typeparam name="TValue">The value type.</typeparam>
    [Serializable]
    public class KeyValuePairComparer<TKey, TValue> : IComparer<KeyValuePair<TKey, TValue>>
    {

        #region Globals

        private readonly IComparer<TKey> comparer;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        public KeyValuePairComparer()
        {
            comparer = Comparer<TKey>.Default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        public KeyValuePairComparer(IComparer<TKey> comparer)
        {

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            this.comparer = comparer;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyValuePairComparer&lt;TKey, TValue&gt;"/> class.
        /// </summary>
        /// <param name="comparison">The comparison.</param>
        public KeyValuePairComparer(Comparison<TKey> comparison)
        {
            if (comparison == null)
            {
                throw new ArgumentNullException("comparison");
            }

            comparer = new ComparisonComparer<TKey>(comparison);
        }

        #endregion

        #region IComparer<KeyValuePairComparer<TKey,TValue>> Members

        /// <inheritdoc />
        public int Compare(KeyValuePair<TKey, TValue> x, KeyValuePair<TKey, TValue> y)
        {
            return comparer.Compare(x.Key, y.Key);
        }

        #endregion

        #region IComparer<TKey> Members

        /// <inheritdoc />
        public int Compare(TKey x, TKey y)
        {
            return comparer.Compare(x, y);
        }

        #endregion

    }

        
   
}
