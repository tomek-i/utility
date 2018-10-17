using System;
using System.Runtime.Serialization;

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
}
