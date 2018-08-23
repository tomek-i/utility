

namespace TI.Utilities.Patterns.Visitor
{
    /// <summary>
    /// A visitor that sums integers in any collection of type int.
    /// </summary>
    public sealed class SumVisitor : IVisitor<int>
    {
        #region Globals

        #endregion


        #region IVisitor<int> Members

        /// <inheritdoc />
        public void Visit(int obj)
        {
            Sum += obj;
        }

        /// <inheritdoc />
        public bool HasCompleted
        {
            get
            {
                return false;
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the sum accumulated by this <see cref="SumVisitor"/>.
        /// </summary>
        /// <value>The sum.</value>
        public int Sum { get; private set; }

        #endregion
    }
}