using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Repository;

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

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
            // Julius
            var products = await _productRepository.GetAllProduct();
            var brands = await _brandRepository.GetAllBrands();
            var colors = await _colorRepository.GetAllColors();
            var images = await _imageRepository.GetAllImages();
            var sizes = await _sizeRepository.GetAllSizes();
            var tags = await _tagRepository.GetAllTags();
            var types = await _typeRepository.GetAllTypes();
            return products.Select(a => a.ToProductResponse(products, tags, brands, colors, images, sizes, types));
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            // Julius
            var products = await _productRepository.GetAllProducts();
            var brands = await _brandRepository.GetAllBrands();
            var colors = await _colorRepository.GetAllColors();
            var images = await _imageRepository.GetAllImages();
            var sizes = await _sizeRepository.GetAllSizes();
            var tags = await _tagRepository.GetAllTags();
            var types = await _typeRepository.GetAllTypes();
            return products?.ToArticleResponse(products, tags, brands, colors, images, sizes, types);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId)
        {   // Julius
            var products = await _productRepository.GetAllProducts();
            var brands = await _brandRepository.GetAllBrands();
            var colors = await _colorRepository.GetAllColors();
            var images = await _imageRepository.GetAllImages();
            var sizes = await _sizeRepository.GetAllSizes();
            var tags = await _tagRepository.GetAllTags();
            var types = await _typeRepository.GetAllTypes();
            return products?.ToArticleResponse(products, tags, brands, colors, images, sizes, types);
        }

        public Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest)
        {
            // Ilona
            throw new NotImplementedException();
        }
    }
}
