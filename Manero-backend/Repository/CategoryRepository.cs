using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_backend.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

      

        public async Task<IEnumerable<CategoryEntity>> GetAllCategoryAsync()
        {
            return await _context.Category.ToListAsync();
        }

          
    }
}
