

namespace TI.Utilities.Patterns.Specification
{
    /// <summary>
    /// An implementation of the specification pattern.  See http://en.wikipedia.org/wiki/Specification_pattern for a detailed description.
    /// </summary>
    /// <typeparam name="T">The type of item the specification is evaluated on.</typeparam>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Determines whether the specification is satisfied by the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        bool IsSatisfiedBy(T item);

        /// <summary>
        /// Performs the AND operation on this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the AND operation.</returns>
        ISpecification<T> And(ISpecification<T> right);

        /// <summary>
        /// Performs the OR operation this specification and the other.
        /// </summary>
        /// <param name="right">The right hand side of the operation.</param>
        /// <returns>The result of the OR operation.</returns>
        ISpecification<T> Or(ISpecification<T> right);

        /// <summary>
        /// Performs the XOR operation on the current specification.
        /// </summary>
        /// <param name="right">The right hand side of the operation..</param>
        /// <returns>The result of the XOR operation.</returns>
        ISpecification<T> Xor(ISpecification<T> right);

        /// <summary>
        /// Performs the NOT operation on the current specification.
        /// </summary>
        /// <returns>The result of the NOT operation.</returns>
        ISpecification<T> Not();
    }
}
