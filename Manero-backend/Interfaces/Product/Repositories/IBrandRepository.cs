using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandEntity>> GetAllBrandAsync();
        Task<BrandEntity> GetByBrandNameAsync(string brand);
        Task<BrandEntity?> GetByIdAsync(int id);
        Task<BrandEntity> GetBrandForProduct(int productId);
    }
}
