using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic; 
using EcommerceSystem.Entity; 
using EcommerceSystem.DAO; 


namespace EcommerceSystem.Tests
{
    [TestClass]
    public class FinanceRepositoryTests
    {
        private IFinanceRepository financeRepo;

        [TestInitialize]
        public void Setup()
        {
            financeRepo = new FinanceRepositoryImpl();
        }

        [TestMethod]
        public void TestCreateUser()
        {
            User user = new User { Username = "testuser", Password = "testpass", Email = "test@example.com" };
            bool result = financeRepo.CreateUser(user);
            Assert.IsTrue(result, "User creation failed.");
        }

        [TestMethod]
        public void TestCreateExpense()
        {
            Expense expense = new Expense { UserId = 1, CategoryId = 1, Amount = 100, Date = DateTime.Now, Description = "Test Expense" };
            bool result = financeRepo.CreateExpense(expense);
            Assert.IsTrue(result, "Expense creation failed.");
        }

        [TestMethod]
        public void TestGetAllExpenses()
        {
            var expenses = financeRepo.GetAllExpenses(1);
            Assert.IsNotNull(expenses, "Expenses retrieval failed.");
        }

        [TestMethod]
        public void TestDeleteUser()
        {
            bool result = financeRepo.DeleteUser(1);
            Assert.IsTrue(result, "User deletion failed.");
        }

        [TestMethod]
        public void TestDeleteExpense()
        {
            bool result = financeRepo.DeleteExpense(1);
            Assert.IsTrue(result, "Expense deletion failed.");
        }
    }
}
