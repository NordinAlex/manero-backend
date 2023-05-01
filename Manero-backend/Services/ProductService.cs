using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Models;
using Manero_backend.Repository;
using System.Linq;

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

        public async Task<ProductResponse> CreateProductAsync(ProductRequest productRequest)
        {
         
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var products = productRequest.ToProductEntity();
            await _productRepository.AddProductAsync(products);
            return products.ToProductResponse(tags, brands, colors, images, sizes, types);
        }

        public Task DeleteProductAsync(int id)
        {
            // Ilona
            await _productRepository.DeleteProduct(id);
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
            // Julius
            var products = await _productRepository.GetAllProductAsync();
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types));
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            // Julius
            var products = await _productRepository.GetProductByIdAsync(id);
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            return products.ToProductResponse( tags, brands, colors, images, sizes, types);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId)
        {   // Julius
            var products = await _productRepository.GetProductByTypeIdAsync(TypeId);
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types));
        }

        public Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest)
        {
            // Ilona
            var brands = await _brandRepository.GetAllTags();
            var colors = await _colorRepository.GetAllColors();
            var images = await _imageRepository.GetAllImages();
            var sizes = await _sizeRepository.GetAllSizes();
            var tags = await _tagRepository.GetAllTags();
            var types = await _typeRepository.GetAllTypes();
            var product = await _productRepository.GetProductById(id);
            if (product == null) return null;

            productRequest.UpdateProduct(product);
            await _productRepository.UpdateProduct(product);

            return product.ToProductResponse(tags, brands, colors, images, sizes, types);
        }
    }
}
