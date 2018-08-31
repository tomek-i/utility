using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TI.Utilities.Patterns.Singleton
{
    [Serializable]
    internal class SingletonConstructorException : Exception
    {
        private Exception _exception;

        public SingletonConstructorException()
        {
        }

        public SingletonConstructorException(Exception exception)
        {
            this._exception = exception;
        }

        public SingletonConstructorException(string message) : base(message)
        {
        }

        public SingletonConstructorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SingletonConstructorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

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
