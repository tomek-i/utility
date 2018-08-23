

namespace TI.Utilities.Patterns.Conversion
{
    /// <summary>
    /// A bidirectional converter.
    /// </summary>
    /// <typeparam name="T1">The type of the one item.</typeparam>
    /// <typeparam name="T2">The type of the other item.</typeparam>
    public interface IBidirectionalConverter<T1, T2>
    {

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        T1 Convert(T2 input);

        /// <summary>
        /// Converts the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        T2 Convert(T1 input);
    }
}