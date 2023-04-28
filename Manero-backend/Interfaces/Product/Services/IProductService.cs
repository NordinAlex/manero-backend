using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
        Task<IEnumerable<ProductDto>> GetProductByTypeIdAsync(int TypeId);
        Task<ProductDto> CreateProductAsync(CreateProductDto productRequest);
        Task<ProductDto> UpdateProductAsync(int id, CreateProductDto productRequest);
        Task DeleteProductAsync(int id);
    }
}
