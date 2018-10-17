using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TI.Utilities.Patterns.Singleton
{

    /// <summary>
    /// Static factory class for implementing the singleton pattern on Types
    /// which contain a private, parameter-less constructor.
    /// </summary>
    /// <typeparam name="T">The underlying singleton type.</typeparam>
    public abstract class Singleton<T> where T : Singleton<T>
    {
        private static readonly Lazy<T> _instance;

        /// <summary>
        /// Default static constructor initializes Lazy constructor.
        /// </summary>
        static Singleton()
        {
            _instance = new Lazy<T>(() =>
            {
                try
                {
                    // Binding flags include private constructors.
                    var constructor = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                    return (T)constructor.Invoke(null);
                }
                catch (Exception exception)
                {
                    throw new SingletonConstructorException(exception);
                }
            });
        }

        /// <summary>
        /// Get the singleton instance for the class.
        /// </summary>
        public static T Instance => _instance.Value;
    }
}
