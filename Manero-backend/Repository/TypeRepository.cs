using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DataContext _context;
        public TypeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TypeEntity>> GetAllTypeAsync()
        {
           return await _context.Types.ToListAsync();
        }
        public async Task<IEnumerable<TypeEntity>> GetTypesForProduct(int productId)
        {
            return await _context.ProductTypes
                .Where(pt => pt.ProductEntityId == productId)
                .Select(pt => pt.TypeEntity)
                .ToListAsync();
        }
    }
}
