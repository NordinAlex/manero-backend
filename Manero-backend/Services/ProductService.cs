using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;

namespace Manero_backend.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ITypeRepository _typeRepository;

        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository, IColorRepository colorRepository, IImageRepository imageRepository, ISizeRepository sizeRepository, ITagRepository tagRepository, ITypeRepository typeRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _imageRepository = imageRepository;
            _sizeRepository = sizeRepository;
            _tagRepository = tagRepository;
            _typeRepository = typeRepository;
        }

        public Task<ProductResponse> CreateProductAsync(ProductRequest productRequest)
        {
            // Alex
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            // Ilona
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
            // Julius
            throw new NotImplementedException();
        }

        public Task<ProductResponse> GetProductByIdAsync(int id)
        {
            // Julius
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId)
        {   // Julius
            throw new NotImplementedException();
        }

        public Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest)
        {
            // Ilona
            throw new NotImplementedException();
        }
    }
}
