using System;
using EcommerceApp.DAO;
using EcommerceApp.Entities;
using EcommerceApp.Exceptions;

namespace EcommerceApp.app
{
    class FinanceApp
    {
        static void Main(string[] args)
        {
            IFinanceRepository financeRepository = new FinanceRepositoryImpl();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Add User");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. Delete User");
                Console.WriteLine("4. Delete Expense");
                Console.WriteLine("5. Update Expense");
                Console.WriteLine("6. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddUser(financeRepository);
                        break;
                    case "2":
                        AddExpense(financeRepository);
                        break;
                    case "3":
                        DeleteUser(financeRepository);
                        break;
                    case "4":
                        DeleteExpense(financeRepository);
                        break;
                    case "5":
                        UpdateExpense(financeRepository);
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        static void AddUser(IFinanceRepository financeRepository)
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

            bool success = financeRepository.CreateUser(newUser);
            Console.WriteLine(success ? "User added successfully!" : "Failed to add user.");
        }

        static void AddExpense(IFinanceRepository financeRepository)
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Description:");
            string description = Console.ReadLine();

            Expense newExpense = new Expense
            {
                UserId = userId,
                Amount = amount,
                CategoryId = categoryId,
                Date = DateTime.Now,
                Description = description
            };

            bool success = financeRepository.CreateExpense(newExpense);
            Console.WriteLine(success ? "Expense added successfully!" : "Failed to add expense.");
        }

        static void DeleteUser(IFinanceRepository financeRepository)
        {
            Console.WriteLine("Enter User ID to delete:");
            int userId = int.Parse(Console.ReadLine());

            try
            {
                bool success = financeRepository.DeleteUser(userId);
                Console.WriteLine(success ? "User deleted successfully!" : "Failed to delete user.");
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteExpense(IFinanceRepository financeRepository)
        {
            Console.WriteLine("Enter Expense ID to delete:");
            int expenseId = int.Parse(Console.ReadLine());

            try
            {
                bool success = financeRepository.DeleteExpense(expenseId);
                Console.WriteLine(success ? "Expense deleted successfully!" : "Failed to delete expense.");
            }
            catch (ExpenseNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void UpdateExpense(IFinanceRepository financeRepository)
        {
            Console.WriteLine("Enter User ID:");
            int userId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Expense ID:");
            int expenseId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Amount:");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Category ID:");
            int categoryId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Description:");
            string description = Console.ReadLine();

            Expense updatedExpense = new Expense
            {
                ExpenseId = expenseId,
                UserId = userId,
                Amount = amount,
                CategoryId = categoryId,
                Date = DateTime.Now,
                Description = description
            };

            bool success = financeRepository.UpdateExpense(userId, updatedExpense);
            Console.WriteLine(success ? "Expense updated successfully!" : "Failed to update expense.");
        }
    }
}

