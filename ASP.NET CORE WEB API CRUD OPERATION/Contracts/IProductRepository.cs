using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts
{
    public interface IProductRepository
    {
        Task<Product> CreateAsync(Product product);
        Task<Product?> GetAsync(int? productId);
         
    }
}
