using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly DataContext _context;
        public TypeRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TypeEntity>> GetAllTypeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
