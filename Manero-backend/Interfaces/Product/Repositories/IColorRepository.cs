using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IColorRepository
    {
        Task<IEnumerable<ColorEntity>> GetAllColorAsync();
        Task<ColorEntity> GetByColorAsync(int color);
        Task<IEnumerable<ColorEntity>> GetColorsForProduct(int productId);
    }
}
