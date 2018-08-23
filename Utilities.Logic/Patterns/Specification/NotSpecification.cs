﻿



namespace TI.Utilities.Patterns.Specification
{
    /// <summary>
    /// Performs an OR operation between two specifications.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NotSpecification<T> : AbstractSpecification<T>
    {
        #region Globals

        private readonly ISpecification<T> specification;

        #endregion

        #region Construction

        /// <summary>
        /// Initializes a new instance of the <see cref="NotSpecification&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="specification">The specification.</param>
        public NotSpecification(ISpecification<T> specification)
        {
            #region Validation

            Guard.ArgumentNotNull(specification, "specification");

            #endregion

            this.specification = specification;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the specification.
        /// </summary>
        /// <value>The specification.</value>
        public ISpecification<T> Specification
        {
            get
            {
                return specification;
            }
        }

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
        /// <code source="..\..\Source\Examples\ExampleLibraryCSharp\Patterns\Specification\NotSpecificationExamples.cs" region="IsSatisfiedBy" lang="cs" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// <code source="..\..\Source\Examples\ExampleLibraryVB\Patterns\Specification\NotSpecificationExamples.vb" region="IsSatisfiedBy" lang="vbnet" title="The following example shows how to use the IsSatisfiedBy method."/>
        /// </example>
        public override bool IsSatisfiedBy(T item)
        {
            return !specification.IsSatisfiedBy(item);
        }

        #endregion
    }
}
