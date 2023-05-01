using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IImageRepository
    {
        Task<IEnumerable<ImagesEntity>> GetAllImageAsync();
    }
}
