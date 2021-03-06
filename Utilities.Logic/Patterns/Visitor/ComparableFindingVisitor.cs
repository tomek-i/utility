
using System;

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that searches objects for an equality, using the <see cref="IComparable"/> interface.
    /// </summary>	
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public sealed class ComparableFindingVisitor<T> : IFindingIVisitor<T> where T : IComparable
    {
        #region Globals

        private readonly T searchValue;

        #endregion

        #region Construction

        /// <param name="searchValue">The search value.</param>
        public ComparableFindingVisitor(T searchValue)
        {
            this.searchValue = searchValue;
        }

        #endregion

        #region IVisitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted { get; private set; }

        /// <summary>
        /// Visits the specified object.
        /// </summary>
        /// <param name="obj">The object to visit.</param>
        public void Visit(T obj)
        {
            if (obj.CompareTo(searchValue) == 0)
            {
                HasCompleted = true;
            }
        }

        #endregion

        #region IFindingIVisitor<T> Members

        /// <summary>
        /// Gets a value indicating whether this <see cref="ComparableFindingVisitor&lt;T&gt;"/> is found.
        /// </summary>
        /// <value><c>true</c> if found; otherwise, <c>false</c>.</value>
        public bool Found
        {
            get
            {
                return HasCompleted;
            }
        }

        /// <summary>
        /// Gets the search value.
        /// </summary>
        /// <value>The search value.</value>
        public T SearchValue
        {
            get
            {
                return searchValue;
            }
        }

        #endregion
    }
}