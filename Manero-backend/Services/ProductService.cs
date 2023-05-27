using Azure.Core;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Models;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Repository;
using System.Linq;
using System.Linq.Expressions;

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
            var productEntity = productRequest.ToProductEntity();

            foreach (var variantRequest in productRequest.Variants)
            {
                var brandE = await _brandRepository.GetByIdAsync(productEntity.BrandEntityId);
                var colorEntity = await _colorRepository.GetByColorAsync(variantRequest.Color);
                var sizeEntity = await _sizeRepository.GetBySizeAsync(variantRequest.Size);
                var imageEntities = variantRequest.ImageName?.Zip(variantRequest.ImageAlt, (name, alt) => new ImagesEntity { ImageName = name, ImageAlt = alt }).ToList();

                var productItemEntity = new ProductItemEntity
                {
                    Product = products,
                    Name = productRequest.Name,
                    Color = colorEntity,
                    Size = sizeEntity,
                    SKU = $"{brandE?.BrandCode}-{colorEntity.ColorCode}-{sizeEntity.Size}-{productRequest.SeasonNumber.ToString().Substring(0, 2)}",
                    QuantityInStock = variantRequest.Stock,
                    Price = variantRequest.Price,
                    Images = imageEntities,
                };
                //foreach (var image in imageEntities)
                //{
                //    image.Id = productItemEntity.Id;
                //}

                products.Variants.Add(productItemEntity);
            }


            await _productRepository.UpdateAsync(products);


            return products.ToProductResponse(tags, brands, colors, images, sizes, types);
        }

        public async Task DeleteProductAsync(int id)
        {
            // Ilona
            await _productRepository.DeleteAsync(id);
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
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types));
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

            return products.ToProductResponse(tags, brands, colors, images, sizes, types);
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
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types));
        }

        public async Task<ProductResponse> UpdateProductAsync(int id, ProductRequest productRequest)
        {
            // Ilona
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            productRequest.UpdateProductEntity(product);
            await _productRepository.UpdateAsync(product);

            return product.ToProductResponse(tags, brands, colors, images, sizes, types);
        }

        public async Task<IEnumerable<ProductResponse>> GetProductBySearchAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            var products = await _productRepository.GetBySearchAsync(predicate);
            var brands = await _brandRepository.GetAllBrandAsync();
            var colors = await _colorRepository.GetAllColorAsync();
            var images = await _imageRepository.GetAllImageAsync();
            var sizes = await _sizeRepository.GetAllSizeAsync();
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            var items = await _productItemRepository.GetAllAsync();
            return products.Select(a => a.ToProductResponse(tags, brands, colors, images, sizes, types));
        }
       
     

    }
}
