namespace EcommerceSystem.Entity
{
    public class ExpenseCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ExpenseCategory() { }

        public ExpenseCategory(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public override string ToString()
        {
            return $"Category [CategoryId={CategoryId}, CategoryName={CategoryName}]";
        }
    }
}
