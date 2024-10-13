using System;

namespace EcommerceApp.Exceptions
{
    public class ExpenseNotFoundException : Exception
    {
        public ExpenseNotFoundException(string message) : base(message)
        {
        }
    }
}
