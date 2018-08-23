


namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// An in order implementation of the <see cref="OrderedVisitor{T}"/> class.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public sealed class InOrderVisitor<T> : OrderedVisitor<T>
    {
        #region Construction

        /// <param name="visitor">The visitor.</param>
        public InOrderVisitor(IVisitor<T> visitor) : base(visitor) { }

        #endregion

        #region OrderedVisitor<T> Members
				
        /// <summary>
        /// Visits the object in post order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitPostOrder(T obj)
        {
            // Do nothing.
        }

        /// <summary>
        /// Visits the object in pre order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitPreOrder(T obj)
        {
            // Do nothing.
        }

        #endregion
    }
}