using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<ImagesEntity>> GetAllImageAsync();
        Task<ImagesEntity> AddAsync(ImagesEntity image); 
        Task<ImagesEntity> GetByIdAsync(int id);
        Task UpdateAsync(ImagesEntity image);
        Task DeleteAsync(int id);
    }
}
