using System;
using System.Runtime.Serialization;

namespace ShoppingBird.Desktop.Exceptions
{
    [Serializable]
    internal class NoItemSelectedException : Exception
    {
        public NoItemSelectedException()
        {
        }

        public NoItemSelectedException(string message) : base(message)
        {
        }

        public NoItemSelectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoItemSelectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}