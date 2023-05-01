using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class ImageRepository : IImageRepository
    {
        private readonly DataContext _context;
        public ImageRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImagesEntity>> GetAllImageAsync()
        {
            return await _context.Images.ToListAsync();
        }
    }
}
