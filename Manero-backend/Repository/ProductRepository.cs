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

        public async Task AddProductAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductAsync()
        {
            return await _context.Products.Include(a => a.BrandEntity).Include(x => x.Wishlist).Include(t => t.Images).Include(z => z.ReviewEntity).Include(y => y.Sizes).Include(p => p.Tags).Include(m => m.Colors).Include(c => c.Type).ToListAsync();
        }

        public async Task<ProductEntity> GetProductByIdAsync(int id)
        {
            return await _context.Products.Include(a => a.BrandEntity).Include(x => x.Wishlist).Include(t => t.Images).Include(z => z.ReviewEntity).Include(y => y.Sizes).Include(p => p.Tags).Include(m => m.Colors).Include(c => c.Type).FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductByTypeIdAsync(int TypeId)
        {
            return await _context.Products.Include(a => a.BrandEntity).Include(x => x.Wishlist).Include(t => t.Images).Include(z => z.ReviewEntity).Include(y => y.Sizes).Include(p => p.Tags).Include(m => m.Colors).Include(c => c.Type).ToListAsync();
        }

        public async Task UpdateProductAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

      
    }
}
