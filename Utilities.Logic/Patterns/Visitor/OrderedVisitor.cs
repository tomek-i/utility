

using System;
using System.Diagnostics.CodeAnalysis;


namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that visits objects in order (PreOrder, PostOrder, or InOrder).
    /// Used primarily as a base class for Visitors specializing in a specific order type.
    /// </summary>
    /// <typeparam name="T">The type of objects to be visited.</typeparam>
    public class OrderedVisitor<T> : IVisitor<T>
    {
        #region Globals

        private readonly IVisitor<T> visitorToUse;

        #endregion

        #region Construction

        /// <param name="visitorToUse">The visitor to use when visiting the object.</param>
        /// <exception cref="ArgumentNullException"><paramref name="visitorToUse"/> is a null reference (<c>Nothing</c> in Visual Basic).</exception>
        public OrderedVisitor(IVisitor<T> visitorToUse)
        {
            Guard.ArgumentNotNull(visitorToUse, "visitorToUse");

            this.visitorToUse = visitorToUse;
        }

        #endregion

        #region IOrderedVisitor<T> Members

        /// <summary>
        /// Determines whether this visitor is done.
        /// </summary>
        /// <value></value>
        /// <returns>
        /// 	<c>true</c> if this visitor is done; otherwise, <c>false</c>.
        /// </returns>
        public bool HasCompleted
        {
            get
            {
                return visitorToUse.HasCompleted;
            }
        }

        /// <summary>
        /// Visits the object in pre order.
        /// </summary>
        /// <param name="obj">The obj.</param>         
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "PreOrder")]
        public virtual void VisitPreOrder(T obj)
        {
            visitorToUse.Visit(obj);
        }

        /// <summary>
        /// Visits the object in post order.
        /// </summary>
        /// <param name="obj">The obj.</param>        
        public virtual void VisitPostOrder(T obj)
        {
            visitorToUse.Visit(obj);
        }

        /// <summary>
        /// Visits the object in order.
        /// </summary>
        /// <param name="obj">The obj.</param>
        public virtual void VisitInOrder(T obj)
        {
            visitorToUse.Visit(obj);
        }
        /// <inheritdoc />
        public void Visit(T obj)
        {
            visitorToUse.Visit(obj);
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the visitor to use.
        /// </summary>
        /// <value>The visitor to use.</value>
        public IVisitor<T> VisitorToUse
        {
            get
            {
                return visitorToUse;
            }
        }

        #endregion
    }
}