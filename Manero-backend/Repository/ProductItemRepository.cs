using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_backend.Repository
{
    public class ProductItemRepository : IProductItemRepository
    {
        private readonly DataContext _context;
        public ProductItemRepository (DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductItemEntity product)
        {
            _context.ProductItems.Add(product);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductItemEntity>> GetAllAsync()
        {
            return await _context.ProductItems.Include(a => a.Color).Include(z => z.Size).Include(p => p.Images).Include(c => c.Product).ToListAsync();
        }

        public Task<ProductItemEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

     

        public Task<IEnumerable<ProductItemEntity>> GetBySearchAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductItemEntity>> GetByTypeIdAsync(int TypeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> SearchAndFilterAsync(SearchFilterRequest searchFilterRequest)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductItemEntity product)
        {
            throw new NotImplementedException();
        }
    }
}
