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
        private readonly IProductItemRepository _productItemRepository;

        public ProductService(IProductRepository productRepository, IBrandRepository brandRepository, IColorRepository colorRepository, IImageRepository imageRepository, ISizeRepository sizeRepository, ITagRepository tagRepository, ITypeRepository typeRepository, IProductItemRepository productItemRepository)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _imageRepository = imageRepository;
            _sizeRepository = sizeRepository;
            _tagRepository = tagRepository;
            _typeRepository = typeRepository;
            _productItemRepository = productItemRepository;
        }

        public async Task<ProductResponse> CreateProductAsync(ProductRequest productRequest)
        {

            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var Item = await _productItemRepository.GetAllAsync();
            var products = productRequest.ToProductEntity();
            await _productRepository.AddAsync(products);
            return products.ToProductResponse(tags, brands, colors, images, sizes, types, Item);
        }

        public Task DeleteProductAsync(int id)
        {
            // Ilona
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductAsync()
        {
            // Julius
            var products = await _productRepository.GetAllAsync();
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var items = await _productItemRepository.GetAllAsync();
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types, items));
        }

        public async Task<ProductResponse> GetProductByIdAsync(int id)
        {
            // Julius
            var products = await _productRepository.GetByIdAsync(id);
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var items = await _productItemRepository.GetAllAsync();
            return products.ToProductResponse(tags, brands, colors, images, sizes, types,items );
        }

        public async Task<IEnumerable<ProductResponse>> GetProductByTypeIdAsync(int TypeId)
        {   // Julius
            var products = await _productRepository.GetByTypeIdAsync(TypeId);
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var items = await _productItemRepository.GetAllAsync();
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types,items));
        }

        public Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest)
        {
            // Ilona
            throw new NotImplementedException();
        }
    }
}
