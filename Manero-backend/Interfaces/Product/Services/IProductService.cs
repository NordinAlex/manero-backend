using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponse>> GetAllProductAsync();
        Task<ProductResponse> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId);
        Task<ProductResponse> CreateProductAsync(ProductRequest productRequest);
        Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest);
        Task DeleteProductAsync(int id);
    }
}
