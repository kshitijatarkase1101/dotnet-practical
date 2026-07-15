using System;

namespace StationeryStoreManagement.Exceptions
{
    public class InvalidPriceException : Exception
    {
        public InvalidPriceException()
            : base("Price should be greater than 0.")
        {
        }

        public InvalidPriceException(string message)
            : base(message)
        {
        }
    }
}