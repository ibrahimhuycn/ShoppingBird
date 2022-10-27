using System;
using System.Runtime.Serialization;

namespace ShoppingBird.Desktop.Exceptions
{
    [Serializable]
    internal class CartItemNotFoundForStoreException : Exception
    {
        public CartItemNotFoundForStoreException()
        {
        }

        public CartItemNotFoundForStoreException(string message) : base(message)
        {
        }

        public CartItemNotFoundForStoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CartItemNotFoundForStoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}