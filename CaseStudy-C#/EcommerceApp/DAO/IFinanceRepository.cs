﻿using EcommerceApp.Entities;
using System.Collections.Generic;

namespace EcommerceApp.DAO
{
    public interface IFinanceRepository
    {
        bool CreateUser(User user);
        bool CreateExpense(Expense expense);
        bool DeleteUser(int userId);
        bool DeleteExpense(int expenseId);
        List<Expense> GetAllExpenses(int userId);
        bool UpdateExpense(int userId, Expense expense);
    }
}
