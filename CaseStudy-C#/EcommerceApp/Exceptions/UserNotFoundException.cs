using System;

namespace EcommerceApp.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
