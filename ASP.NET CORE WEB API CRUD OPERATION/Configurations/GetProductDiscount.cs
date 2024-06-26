using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.DTOs.Product;
using AutoMapper;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Configurations
{
    public class GetProductDiscount : IValueResolver<Product, ProductDto, decimal>
    {
        public decimal Resolve(Product source, ProductDto destination, decimal destMember, ResolutionContext context)
        {
            return source.Price - source.Category.CategoryDiscount;
        }
    }
}
