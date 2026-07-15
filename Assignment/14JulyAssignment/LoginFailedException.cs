using System;

namespace StationeryStoreManagement.Exceptions
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base("Maximum login attempts exceeded.")
        {
        }

        public LoginFailedException(string message)
            : base(message)
        {
        }
    }
}