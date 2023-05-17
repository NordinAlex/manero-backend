using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface ISizeRepository
    {
        Task<IEnumerable<SizeEntity>> GetAllSizeAsync();
        Task<SizeEntity> GetBySizeAsync(int size);
    }
}
