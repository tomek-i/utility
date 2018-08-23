using System;
using System.Collections.Generic;

namespace TI.Utilities.Comparers
{
    /// <summary>
    /// A Comparer using a Comparison delegate for comparisons between items.
    /// </summary>
    /// <typeparam name="T">The type of the objects to compare.</typeparam>
    [Serializable]
    public sealed class ReverseComparisonComparer<T> : IComparer<T>
    {
        #region Globals

        private Comparison<T> comparison;

        #endregion

        #region Construction


        /// <param name="comparison">The comparison.</param>
        /// <exception cref="ArgumentNullException"><paramref name="comparison"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public ReverseComparisonComparer(Comparison<T> comparison)
        {
            Guard.ArgumentNotNull(comparison, "comparison");

            this.comparison = comparison;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets or sets the comparison used in this comparer.
        /// </summary>
        /// <value>The comparison used in this comparer.</value>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public Comparison<T> Comparison
        {
            get
            {
                return comparison;
            }
            set
            {

                Guard.ArgumentNotNull(value, "value");

                comparison = value;
            }
        }

        #endregion

        #region IComparer<T> Members

        /// <inheritdoc />
        public int Compare(T x, T y)
        {
            return comparison(y, x);
        }

        #endregion
    }

}