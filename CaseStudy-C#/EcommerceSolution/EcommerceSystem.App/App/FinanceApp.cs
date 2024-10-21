using System;
using System.Collections.Generic;
using EcommerceSystem.DAO;
using EcommerceSystem.Entity;
using EcommerceSystem.Exceptions;

namespace EcommerceSystem.App
{
    public class FinanceApp
    {
        private static FinanceRepositoryImpl _financeRepository;

        public static void Main(string[] args)
        {
            _financeRepository = new FinanceRepositoryImpl();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Get Users List");
                Console.WriteLine("3. Add Expense");
                Console.WriteLine("4. Delete User");
                Console.WriteLine("5. Delete Expense");
                Console.WriteLine("6. Update Expense");
                Console.WriteLine("7. Exit");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        GetUsersList();
                        break;
                    case 3:
                        AddExpense();
                        break;
                    case 4:
                        DeleteUser();
                        break;
                    case 5:
                        DeleteExpense();
                        break;
                    case 6:
                        UpdateExpense();
                        break;
                    case 7:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        private static void AddUser()
        {
            Console.WriteLine("Enter Username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter Password:");
            string password = Console.ReadLine();
            Console.WriteLine("Enter Email:");
            string email = Console.ReadLine();

            User newUser = new User
            {
                Username = username,
                Password = password,
                Email = email
            };

            bool result = _financeRepository.CreateUser(newUser);
            if (result)
            {
                Console.WriteLine("User created successfully.");
            }
            else
            {
                Console.WriteLine("Error creating user.");
            }
        }

        private static void GetUsersList()
        {
            List<User> users = _financeRepository.GetAllUsers();
            if (users.Count > 0)
            {
                Console.WriteLine("Users List:");
                foreach (var user in users)
                {
                    Console.WriteLine($"User ID: {user.UserId}, Username: {user.Username}, Email: {user.Email}");
                }
            }
            else
            {
                Console.WriteLine("No users found.");
            }
        }

        private static void AddExpense()
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Date (yyyy-mm-dd):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();

            Expense newExpense = new Expense
            {
                UserId = userId,
                Amount = amount,
                CategoryId = categoryId,
                Date = date,
                Description = description
            };

            bool result = _financeRepository.CreateExpense(newExpense);
            if (result)
            {
                Console.WriteLine("Expense added successfully.");
            }
            else
            {
                Console.WriteLine("Error adding expense.");
            }
        }

        private static void DeleteUser()
        {
            Console.WriteLine("Enter User ID to delete:");
            int userId = int.Parse(Console.ReadLine());
            bool result = _financeRepository.DeleteUser(userId);
            if (result)
            {
                Console.WriteLine("User deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error deleting user.");
            }
        }

        private static void DeleteExpense()
        {
            Console.WriteLine("Enter Expense ID to delete:");
            int expenseId = int.Parse(Console.ReadLine());
            bool result = _financeRepository.DeleteExpense(expenseId);
            if (result)
            {
                Console.WriteLine("Expense deleted successfully.");
            }
            else
            {
                Console.WriteLine("Error deleting expense.");
            }
        }

        private static void UpdateExpense()
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Expense ID to update:");
            int expenseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Date (yyyy-mm-dd):");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Description:");
            string description = Console.ReadLine();

            Expense updatedExpense = new Expense
            {
                ExpenseId = expenseId, 
                UserId = userId,
                Amount = amount,
                CategoryId = categoryId,
                Date = date,
                Description = description
            };

            bool result = _financeRepository.UpdateExpense(userId, updatedExpense);
            if (result)
            {
                Console.WriteLine("Expense updated successfully.");
            }
            else
            {
                Console.WriteLine("Error updating expense.");
            }
        }
    }
}
