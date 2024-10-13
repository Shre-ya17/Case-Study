using EcommerceApp.DAO;
using EcommerceApp.Entities;
using EcommerceApp.Exceptions;
using System.Collections.Generic;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace EcommerceApp.UnitTest
{
    [TestClass]
    public class FinanceRepositoryTests
    {
        private IFinanceRepository financeRepository;

        [TestInitialize]
        public void Setup() => financeRepository = new FinanceRepositoryImpl();

        [TestMethod]
        public void CreateUser_ShouldReturnTrue_WhenUserIsValid()
        {
            User user = new User
            {
                Username = "testuser",
                Password = "testpassword",
                Email = "test@test.com"
            };
            var repository = new FinanceRepositoryImpl();

            bool result = financeRepository.CreateUser(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CreateExpense_ShouldReturnTrue_WhenExpenseIsValid()
        {
            Expense expense = new Expense
            {
                UserId = 1,
                Amount = 100.50m,
                CategoryId = 1,
                Date = System.DateTime.Now,
                Description = "Test expense"
            };

            bool result = financeRepository.CreateExpense(expense);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void DeleteUser_ShouldThrowUserNotFoundException_WhenUserDoesNotExist()
        {
            financeRepository.DeleteUser(999); // Assuming 999 is not a valid userId in the DB
        }

        [TestMethod]
        [ExpectedException(typeof(ExpenseNotFoundException))]
        public void DeleteExpense_ShouldThrowExpenseNotFoundException_WhenExpenseDoesNotExist()
        {
            financeRepository.DeleteExpense(999); // Assuming 999 is not a valid expenseId in the DB
        }

        [TestMethod]
        public void GetAllExpenses_ShouldReturnListOfExpenses_ForUser()
        {
            int userId = 1;
            List<Expense> expenses = financeRepository.GetAllExpenses(userId);

            Assert.IsNotNull(expenses);
            Assert.IsTrue(expenses.Count > 0);
        }

        [TestMethod]
        public void UpdateExpense_ShouldReturnTrue_WhenExpenseIsUpdated()
        {
            Expense expense = new Expense
            {
                ExpenseId = 1,
                UserId = 1,
                Amount = 150.75m,
                CategoryId = 1,
                Date = System.DateTime.Now,
                Description = "Updated expense"
            };

            bool result = financeRepository.UpdateExpense(1, expense);

            Assert.IsTrue(result);
        }
    }
}
