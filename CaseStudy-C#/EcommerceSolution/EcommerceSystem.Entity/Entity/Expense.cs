using System;

namespace EcommerceSystem.Entity
{
    public class Expense
    {
        public int ExpenseId { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public Expense() { }

        public Expense(int expenseId, int userId, int categoryId, decimal amount, DateTime date, string description)
        {
            ExpenseId = expenseId;
            UserId = userId;
            CategoryId = categoryId;
            Amount = amount;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"Expense [ExpenseId={ExpenseId}, UserId={UserId}, CategoryId={CategoryId}, Amount={Amount}, Date={Date}, Description={Description}]";
        }
    }
}
