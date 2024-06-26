namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int CategoryDiscount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
