using System;

namespace TI.Utilities.Extensions
{
    /// <summary>
    /// Provides extension methods to the Double type.
    /// </summary>
    public static class DoubleExtensions
    {
        #region Globals

        /// <summary>
        /// The default precision catered for in checking whether or not values are similar.
        /// </summary>
        public const double DefaultPrecision = 0.00000000001d;

        #endregion

        #region Public Members

        /// <summary>
        /// Checks if arguments are very close in values. If true we could assume they 
        /// refer to the same value. 
        /// </summary>
        /// <param name="arg1">The 1st argument value to check.</param>
        /// <param name="arg2">The 1st argument value to check.</param>
        public static bool IsSimilarTo(this double arg1, double arg2)
        {
            return IsSimilarTo(arg1, arg2, DefaultPrecision);
        }

        /// <summary>
        /// Checks if arguments are very close in values using given precision perimeters. If true we could assume they 
        /// refer to the same value. 
        /// </summary>
        /// <param name="arg1">The 1st argument value to check.</param>
        /// <param name="arg2">The 1st argument value to check.</param>
        /// <param name="precision">The precision.</param>
        public static bool IsSimilarTo(this double arg1, double arg2, double precision)
        {
            return Math.Abs(arg1 - arg2) < precision;
        }

        #endregion
    }
}