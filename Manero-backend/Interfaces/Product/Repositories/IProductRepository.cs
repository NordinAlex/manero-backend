using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Interfaces.Product
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductAsync();
        Task<ProductEntity> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductEntity>> GetProductByTypeIdAsync(int TypeId);
        Task AddProductAsync(ProductEntity product);
        Task UpdateProductAsync(ProductEntity product);
        Task DeleteProductAsync(int id);
    }
}
