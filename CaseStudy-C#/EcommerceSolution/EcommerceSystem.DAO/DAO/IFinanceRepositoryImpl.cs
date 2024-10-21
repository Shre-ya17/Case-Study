using EcommerceSystem.Entity;
using System.Collections.Generic;

namespace EcommerceSystem.DAO
{
    public interface IFinanceRepository
    {
        bool CreateUser(User user);
        List<User> GetAllUsers();
        bool CreateExpense(Expense expense);
        bool DeleteUser(int userId);
        bool DeleteExpense(int expenseId);
        bool UpdateExpense(int userId, Expense expense);
        List<Expense> GetAllExpenses(int userId); 
    }
}
