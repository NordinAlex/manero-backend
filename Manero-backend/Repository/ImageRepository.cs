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

        public async Task<ImagesEntity> AddAsync(ImagesEntity image)
        {
            _context.Images.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<IEnumerable<ImagesEntity>> GetAllImageAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<ImagesEntity> GetByIdAsync(int id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task UpdateAsync(ImagesEntity image)
        {
            _context.Images.Update(image);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var image = await GetByIdAsync(id);
            if (image != null)
            {
                _context.Images.Remove(image);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<ImagesEntity>> GetImagesForProduct(int productId)
        {
            return await _context.ProductItems
                .Where(pi => pi.ProductId == productId)
                .SelectMany(pi => pi.Images)
                .ToListAsync();
        }
    }
}
