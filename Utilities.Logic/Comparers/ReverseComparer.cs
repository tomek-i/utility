using System;
using System.Collections.Generic;

namespace TI.Utilities.Comparers
{
    
        /// <summary>
        /// A comparer that wraps the IComparable interface to reproduce the opposite comparison result.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        [Serializable]
        public sealed class ReverseComparer<T> : IComparer<T>
        {
            #region Globals

            private IComparer<T> comparerToUse;

            #endregion

            #region Construction
            /// <inheritdoc />
            public ReverseComparer()
            {
                comparerToUse = Comparer<T>.Default;
            }


            /// <param name="comparer">The comparer to reverse.</param>
            /// <exception cref="ArgumentNullException"><paramref name="comparer"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
            public ReverseComparer(IComparer<T> comparer)
            {

                Guard.ArgumentNotNull(comparer, "comparer");
                comparerToUse = comparer;
            }

            #endregion

            #region IComparer<T> Members

            /// <inheritdoc />
            public int Compare(T x, T y)
            {
                return (comparerToUse.Compare(y, x));
            }

            #endregion

            #region Public Members

            /// <summary>
            /// Gets or sets the comparer used in this instance.
            /// </summary>
            /// <value>The comparer.</value>
            /// <exception cref="ArgumentNullException"><paramref name="value"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
            public IComparer<T> Comparer
            {
                get
                {
                    return comparerToUse;
                }
                set
                {

                    Guard.ArgumentNotNull(value, "value");

                    comparerToUse = value;
                }
            }

            #endregion
        }

   
}
