using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts
{
    public interface ICategoryRepository
    {
        Task<Category?> GetAsync(int? categoryId);

        Task<List<Category>> GetAllAsync();

        Task<Category> CreateAsync(Category category);

        Task DeleteAsync(int categoryId);

        Task UpdateAsync(Category category);
    }
}
