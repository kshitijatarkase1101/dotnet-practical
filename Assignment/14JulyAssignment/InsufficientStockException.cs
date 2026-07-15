using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
            : base("Insufficient stock available.")
        {
        }

        public InsufficientStockException(string message)
            : base(message)
        {
        }
    }
}