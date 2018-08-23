﻿

namespace TI.Utilities.Collections.Mathematical
{
    /// <summary>
    /// Decomposition is the implementation of all  matrix decomposition methods
    /// (a matrix decomposition is a factorization of a matrix into some canonical form) 
    /// </summary>
    public interface IDecomposition
    {
        /// <summary>
        /// Gets left factor of decomposition of original matrix.
        /// </summary>
        /// <returns>The left Factor</returns>
        Matrix LeftFactorMatrix
        {
            get;
        }


        /// <summary>
        /// Gets right factor of decomposition of original matrix.
        /// </summary>
        /// <returns>The right  factor</returns>
        Matrix RightFactorMatrix
        {
            get;
        }

        /// <summary>
        /// Solves the specified equation.
        /// </summary>
        /// <param name="right">The right hand side of the equation.</param>
        /// <returns>The answer.</returns>
        Matrix Solve(Matrix right);

        /// <summary>
        /// Decomposes the specified matrix 
        /// </summary>
        /// <param name="matrix">The matrix to decompose.</param>
        /// <returns>Decomposed matrix</returns>
        void Decompose(Matrix matrix);
    }
}
