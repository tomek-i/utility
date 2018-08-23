

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A Visitor that counts items in a visitable collection.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public sealed class CountingVisitor<T> : IVisitor<T>
    {
        #region Globals

        #endregion

        #region Visitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        /// <inheritdoc />
        public void Visit(T obj)
        {
            Count++;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Resets the count to zero.
        /// </summary>
        public void ResetCount()
        {
            Count = 0;
        }

        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <value>The current count value.</value>
        public int Count { get; private set; }

        #endregion
    }
}