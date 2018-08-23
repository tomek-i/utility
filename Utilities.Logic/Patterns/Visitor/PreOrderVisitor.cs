

using System.Diagnostics.CodeAnalysis;

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that visits objects only in pre order.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PreOrder")]
    public sealed class PreOrderVisitor<T> : OrderedVisitor<T>
    {
        #region Construction

        /// <param name="visitor">The visitor to use when visiting the object.</param>
        public PreOrderVisitor(IVisitor<T> visitor) : base(visitor) { }

        #endregion

        #region OrderedVisitor<T> Members

        /// <summary>
        /// Visits the object in order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitInOrder(T obj)
        {
            // Do nothing.
        }

        /// <summary>
        /// Visits the object in post order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public override void VisitPostOrder(T obj)
        {
            // Do nothing.
        }

        #endregion
    }
}