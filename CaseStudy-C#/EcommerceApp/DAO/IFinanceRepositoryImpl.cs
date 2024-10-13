using EcommerceApp.Entities;
using EcommerceApp.Util;
using EcommerceApp.Exceptions;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EcommerceApp.DAO
{
    public class FinanceRepositoryImpl : IFinanceRepository
    {
        public bool CreateUser(User user)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "INSERT INTO Users (username, password, email) VALUES (@username, @password, @Email)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateExpense(Expense expense)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "INSERT INTO Expenses (user_id, amount, category_id, date, description) VALUES (@userId, @amount, @categoryId, @date, @description)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", expense.UserId);
                cmd.Parameters.AddWithValue("@amount", expense.Amount);
                cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                cmd.Parameters.AddWithValue("@date", expense.Date);
                cmd.Parameters.AddWithValue("@description", expense.Description);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Users WHERE user_id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new UserNotFoundException("User not found.");
                }
                return true;
            }
        }

        public bool DeleteExpense(int expenseId)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "DELETE FROM Expenses WHERE expense_id = @expenseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@expenseId", expenseId);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new ExpenseNotFoundException("Expense not found.");
                }
                return true;
            }
        }

        public List<Expense> GetAllExpenses(int userId)
        {
            List<Expense> expenses = new List<Expense>();
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "SELECT * FROM Expenses WHERE user_id = @userId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@userId", userId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Expense expense = new Expense
                    {
                        ExpenseId = reader.GetInt32(0),
                        UserId = reader.GetInt32(1),
                        Amount = reader.GetDecimal(2),
                        CategoryId = reader.GetInt32(3),
                        Date = reader.GetDateTime(4),
                        Description = reader.GetString(5)
                    };
                    expenses.Add(expense);
                }
            }
            return expenses;
        }

        public bool UpdateExpense(int userId, Expense expense)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                string query = "UPDATE Expenses SET amount = @amount, category_id = @categoryId, date = @date, description = @description WHERE user_id = @userId AND expense_id = @expenseId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@amount", expense.Amount);
                cmd.Parameters.AddWithValue("@categoryId", expense.CategoryId);
                cmd.Parameters.AddWithValue("@date", expense.Date);
                cmd.Parameters.AddWithValue("@description", expense.Description);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@expenseId", expense.ExpenseId);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
