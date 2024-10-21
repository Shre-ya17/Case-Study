using System;

namespace EcommerceSystem.Exceptions
{
    public class ExpenseNotFoundException : Exception
    {
        public ExpenseNotFoundException(string message) : base(message) { }
    }
}
