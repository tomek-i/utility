﻿

namespace TI.Utilities.Patterns.Specification
{
    /// <summary>
    /// Performs an OR operation between two specifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OrSpecification<T> : CompositeSpecification<T>
    {
        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="OrSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="left">The left specification.</param>
        /// <param name="right">The right specification.</param>
        public OrSpecification(ISpecification<T> left, ISpecification<T> right): base(left, right) {}

        #endregion

        #region AbstractSpecification<T> Members

        /// <summary>
        /// Determines whether the specification is satisfied by the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>
        /// 	<c>true</c> if the specification is satisfied by the specified item; otherwise, <c>false</c>.
        /// </returns>
        /// <example>
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Patterns\Specification\OrSpecificationExamples.cs" region="IsSatisfiedBy" lang="cs" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Patterns\Specification\OrSpecificationExamples.vb" region="IsSatisfiedBy" lang="vbnet" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// </example>
        public override bool IsSatisfiedBy(T item)
        {
            return Left.IsSatisfiedBy(item) || Right.IsSatisfiedBy(item);
        }

        #endregion
    }
}
