using ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Product;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Category
{
    public class GetCategoryProductsDto : ProductDto
    {
        public int Id { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public int CategoryDiscount { get; set; }

        public List<ProductDto> Products { get; set; }

        
        
    }
}
