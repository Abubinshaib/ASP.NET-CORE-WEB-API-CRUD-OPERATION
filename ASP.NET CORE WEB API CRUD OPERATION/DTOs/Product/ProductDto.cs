namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Product
{
    public partial class ProductDto 
    {
        
        public int CategoryId { get; set; }
        public string ProductName { get; set; } = null!;
        public int Qty { get; set; }
        public decimal Price { get; set; }
       


    }
}
