using System;
using System.Runtime.Serialization;

namespace ShoppingBird.Desktop.Exceptions
{
    [Serializable]
    internal class NoStoreSelectedException : Exception
    {
        public NoStoreSelectedException()
        {
        }

        public NoStoreSelectedException(string message) : base(message)
        {
        }

        public NoStoreSelectedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoStoreSelectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}