using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _context;
        public SizeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SizeEntity>> GetAllSizeAsync()
        {
            return await _context.Sizes.ToListAsync();
        }
        public async Task<SizeEntity> GetBySizeAsync(int size)
        {
            return await _context.Sizes.FirstOrDefaultAsync(c => c.Id == size);
        }
        public async Task<IEnumerable<SizeEntity>> GetSizesForProduct(int productId)
        {
            return await _context.ProductItems
                .Where(pi => pi.ProductId == productId)
                .Select(pi => pi.Size)
                .ToListAsync();
        }
    }
}
