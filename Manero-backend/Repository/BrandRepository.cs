using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _context;

        public BrandRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BrandEntity>> GetAllBrandAsync()
        {
           return await _context.Brands.ToListAsync();
        }
    }
}
