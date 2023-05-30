using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product;
using Manero_backend.Services;
using Moq;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
using Manero_backend.Interfaces.Product.Services;

namespace Manero_backend_tests.UnitTests
{
    public class ProductService_Tests
    {
        private Mock<IProductRepository> _productRepository;
        private IProductService _productService;       
        public ProductService_Tests()
        {

            _productRepository = new Mock<IProductRepository>();
            var mockBrandRepository = new Mock<IBrandRepository>();
            var mockColorRepository = new Mock<IColorRepository>();
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            var mockImageRepository = new Mock<IImageRepository>();
            var mockSizeRepository = new Mock<ISizeRepository>();
            var mockTagRepository = new Mock<ITagRepository>();
            var mockTypeRepository = new Mock<ITypeRepository>();
            var mockProductItemRepository = new Mock<IProductItemRepository>();

            _productService = new ProductService(
                _productRepository.Object,
                mockBrandRepository.Object,
                mockColorRepository.Object,
                mockImageRepository.Object,
                mockSizeRepository.Object,
                mockTagRepository.Object,
                mockTypeRepository.Object,
                mockProductItemRepository.Object
                //mockCategoryRepository.Object
            );
        }
        [Fact]
        public async Task CreateProductAsync__Should_Create_New_ProductEntity_And_Return_ProductResponse()
        {
            // Arrange
            ProductRequest request = new ProductRequest
            {
                Name = "Product 1",
                Description = "Product 1 Description",
                Featured = true,
                SeasonNumber = 12,
                BrandId = 1,
                CategoryId = 1,
                TagsId = new List<int> { 1 },
                TypeId = new List<int> { 1 },
                Variants = new List<ProductItemRequest>
                {
                new ProductItemRequest
                    {
                     ImageName = new List<string> { "Bild" },
                     ImageAlt = new List<string> { "Bild" },
                     Price = 100,
                     Size =  1,
                     Color = 1,
                     }
                }
            };

            ProductEntity entity = new ProductEntity
            {
                Id = 1,
                Name = "Product 1",
                Description = "Product 1 Description",
                Featured = true,
                BrandEntityId = 1,
                CategoryEntityId = 1,
                BrandEntity = new BrandEntity
                {
                    Id = 1,
                    BrandName = "Brand 1"
                },
                Category = new CategoryEntity
                {
                    Id = 1,
                    Name = "Category 1"
                },
             
                Tags = new List<ProductTagsEntity>
                {
                    new ProductTagsEntity
                    {
                        ProductEntityId = 1,
                        TagsEntityId = 1

                    }

                },


                Variants = new List<ProductItemEntity>
                {
                 new ProductItemEntity
                    {
                     Name = "Product 1",
                     Price = 100,
                     QuantityInStock = 1,

                     SKU = "1",
                     Images = new List<ImagesEntity>
                     {
                         new ImagesEntity
                         {
                             ImageName = "Bild",
                             ImageAlt = "Bild"
                         }
                     },
                     Color = new ColorEntity
                     {
                         Id = 1,
                         Color = "Red"
                     },
                     Size = new SizeEntity
                     {
                         Id = 1,
                         Size = "S"
                     }

                 }
                }
            };

            _productRepository.Setup(x => x.AddAsync(It.IsAny<ProductEntity>())).ReturnsAsync(entity);
            //_productRepository.Setup(x => x.AddAsync(It.IsAny<ProductEntity>())).Returns(Task.CompletedTask);
          


            // Act

            var result = await _productService.CreateProductAsync(request);


            // Assert
            Assert.NotNull(result);
            Assert.IsType<ServiceResponse<ProductResponse>>(result);
            //Assert.True(result.Success, result.Message);

            //Assert.NotNull(result);
            //Assert.IsType<ProductResponse>(result);
        }
    }
}
