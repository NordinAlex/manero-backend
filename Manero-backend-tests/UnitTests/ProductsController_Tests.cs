using Manero_backend.Controllers;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Manero_backend.Tests.Controllers
{
    public class ProductsController_Tests
    {
        private ProductController _productController;
        private Mock<IProductService> _productServiceMock;
        private Mock<ISearchFilterService> _searchFilterServiceMock;

        public ProductsController_Tests()
        {
            _productServiceMock = new Mock<IProductService>();
            _searchFilterServiceMock = new Mock<ISearchFilterService>();
            _productController = new ProductController(_productServiceMock.Object, _searchFilterServiceMock.Object);
        }

        [Fact]
        public async Task GetAll_Should_Return_OkResult_Or_BadRequestResult()
        {
            var products = new List<ProductResponse>
            {
                new ProductResponse { Id = 1, Name = "Product 1" },
                new ProductResponse { Id = 2, Name = "Product 2" },
                new ProductResponse { Id = 3, Name = "Product 3" }
            };

            _productServiceMock
                .Setup(mock => mock.GetAllProductAsync())
                .ReturnsAsync(products);

            var result = await _productController.GetAllProducts();

            if (result.Result is OkObjectResult okResult)
            {
                var value = Assert.IsType<ServiceResponse<IEnumerable<ProductResponse>>>(okResult.Value);
                Assert.Equal(products.Count, value.Data.Count());
            }
            else if (result.Result is BadRequestObjectResult badRequestResult)
            {
                // Handle the BadRequestObjectResult
                var value = Assert.IsType<string>(badRequestResult.Value);
                // Add assertions or other handling specific to the BadRequest case
            }
            else
            {
                Assert.True(false, "Oväntad resultattyp!");
            }
        }
    }
}
