using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class SizeRepository : ISizeRepository
    {
        private readonly DataContext _context;
        public SizeRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<SizeEntity>> GetAllSizeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
