﻿using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Contracts;
using ASP.NET_CORE_WEB_API_CRUD_OPERATION.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_CORE_WEB_API_CRUD_OPERATION.Repository
{
     public class CategoryRepository : ICategoryRepository
     {

        private readonly GeeksStoreContext _context;

        public CategoryRepository(GeeksStoreContext context)
        {
            this._context = context;
        }

        public async Task<Category> CreateAsync(Category category)
        {
            await this._context.AddAsync(category);
            await this._context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteAsync(int categoryId)
        {
            var category = await GetAsync(categoryId);

            if (category is null)
            {
                throw new Exception($"CategoryID {categoryId} is not found.");
            }
            this._context.Set<Category>().Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Set<Category>().ToListAsync();
        }

        public async Task<Category?> GetAsync(int? categoryId)
        {
            if (categoryId == null)
            {
                return null;
            }
            return await this._context.Categories.FindAsync(categoryId);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
     }
}
