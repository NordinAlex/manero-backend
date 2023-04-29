using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext _context;
        public ImageRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<ImagesEntity>> GetAllImageAsync()
        {
            throw new NotImplementedException();
        }
    }
}
