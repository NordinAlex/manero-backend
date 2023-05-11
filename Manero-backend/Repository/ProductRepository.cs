using Manero_backend.Context;
using Manero_backend.Interfaces.Product;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Manero_backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).Include(p => p.Category).Include(c => c.Category).Include(c => c.Variants).ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).FirstOrDefaultAsync(a => a.Id == id);
            return product!;
        }

        public async Task<IEnumerable<ProductEntity>> GetByTypeIdAsync(int TypeId)
        {
            var product = await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).ToListAsync();
            return product!;
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      
    }
}
