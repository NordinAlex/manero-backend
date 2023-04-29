using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly DataContext _context;


        public ColorRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ColorEntity>> GetAllColorAsync()
        {
            throw new NotImplementedException();
        }
    }
}
