using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EcommerceSystem.Entity;
using EcommerceSystem.Util;
using EcommerceSystem.Exceptions;

namespace EcommerceSystem.DAO
{
    public class FinanceRepositoryImpl : IFinanceRepository
    {
        private string _connectionString;

        public FinanceRepositoryImpl()
        {
            _connectionString = PropertyUtil.GetPropertyString(); 
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool CreateUser(User user)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Users (username, password, email) VALUES (@Username, @Password, @Email)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@Email", user.Email);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT user_id, username, password, email FROM Users";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    User user = new User
                    {
                        UserId = (int)reader["user_id"],
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Email = reader["email"].ToString()
                    };
                    users.Add(user);
                }
            }

            return users;
        }

        public bool CreateExpense(Expense expense)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Expenses (user_id, amount, category_id, date, description) VALUES (@UserId, @Amount, @CategoryId, @Date, @Description)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", expense.UserId);
                command.Parameters.AddWithValue("@Amount", expense.Amount);
                command.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
                command.Parameters.AddWithValue("@Date", expense.Date);
                command.Parameters.AddWithValue("@Description", expense.Description);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }

        public bool DeleteUser(int userId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "DELETE FROM Users WHERE user_id = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }

        public bool DeleteExpense(int expenseId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "DELETE FROM Expenses WHERE expense_id = @ExpenseId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ExpenseId", expenseId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }

        public bool UpdateExpense(int userId, Expense expense)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "UPDATE Expenses SET amount = @Amount, category_id = @CategoryId, date = @Date, description = @Description WHERE expense_id = @ExpenseId AND user_id = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Amount", expense.Amount);
                command.Parameters.AddWithValue("@CategoryId", expense.CategoryId);
                command.Parameters.AddWithValue("@Date", expense.Date);
                command.Parameters.AddWithValue("@Description", expense.Description);
                command.Parameters.AddWithValue("@ExpenseId", expense.ExpenseId); 
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                int result = command.ExecuteNonQuery();
                return result > 0; 
            }
        }

        public List<Expense> GetAllExpenses(int userId)
        {
            List<Expense> expenses = new List<Expense>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT expense_id, user_id, amount, category_id, date, description FROM Expenses WHERE user_id = @UserId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserId", userId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Expense expense = new Expense
                    {
                        ExpenseId = (int)reader["expense_id"], 
                        UserId = (int)reader["user_id"],
                        Amount = (decimal)reader["amount"],
                        CategoryId = (int)reader["category_id"],
                        Date = (DateTime)reader["date"],
                        Description = reader["description"].ToString()
                    };
                    expenses.Add(expense);
                }
            }

            return expenses;
        }
    }
}
