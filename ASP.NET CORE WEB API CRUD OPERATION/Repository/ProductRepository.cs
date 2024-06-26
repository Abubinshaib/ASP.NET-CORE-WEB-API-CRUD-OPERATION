using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly GeeksStoreContext _context;

        public ProductRepository(GeeksStoreContext context)
        {
            this._context = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await this._context.AddAsync(product);
            await this._context.SaveChangesAsync();
            return product;
        }

        public async Task<Product?> GetAsync(int? productId)
        {
            if (productId == null)
            {
                return null;
            }
            return await this._context.Products.FindAsync(productId);
        }
    }
}
