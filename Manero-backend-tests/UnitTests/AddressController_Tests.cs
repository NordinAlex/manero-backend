using Manero_backend.Controllers;
using Manero_backend.Interfaces.Addresses.Service;
using Moq;
using Manero_backend_tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Manero_backend.DTOs.Address;
using Manero_backend.Migrations;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Manero_backend_tests.UnitTests
{
    public class AddressController_Tests : IClassFixture<AddressFixture>
    {

        private AddressController _addressController;
        private Mock<IAddressService> _addressService;
        private AddressFixture _addressFixture;

        public AddressController_Tests(AddressFixture addressFixture)
        {
            _addressService = new Mock<IAddressService>();
            _addressController = new AddressController(_addressService.Object);
            _addressFixture = addressFixture;
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateNewAddress_AndReturnAddressResponse()
        {
            //Arrange
            _addressService.Setup(x => x.CreateAddressAsync(_addressFixture.ValidAddressCreateRequest)).ReturnsAsync(_addressFixture.ValidAddressCreateResponse);

            //Act
            var result = await _addressController.CreateAsync(_addressFixture.ValidAddressCreateRequest);

            //Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value as AddressResponse;
            Assert.Equal(_addressFixture.ValidAddressCreateRequest.City, value!.City);
            Assert.Equal(_addressFixture.ValidAddressCreateRequest.BillingAddress, value.BillingAddress);
        }
        [Fact]
        public async Task CreateAsync_WithValidAddressRequestAndFailedCreation_ReturnsBadRequest()
        {
            // Arrange
            
            _addressService.Setup(x => x.CreateAddressAsync(_addressFixture.ValidAddressCreateRequest)).ReturnsAsync(_addressFixture.InvalidAddressCreateResponse);

            // Act
            var result = await _addressController.CreateAsync(_addressFixture.ValidAddressCreateRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;
            var addressResponse = badRequestResult!.Value as AddressResponse;
            Assert.True(addressResponse!.Error);
        }
        [Fact]
        public async Task GetAllUserAddresses_ShouldReturnIActionRsult_WhitAddressResponse()
        {
            // Arrange
           var email = "patrik.byren@hotmail.com"; 
            var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Email, email)
                };
            var claimsIdentity = new ClaimsIdentity(claims);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            _addressController.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext { User = claimsPrincipal }
            };
            _addressService.Setup(x => x.GetAllForOneUserAsync(email)).ReturnsAsync(_addressFixture.ValidGetAllAddressForOneUserResponse);

            // Act
            var result = await _addressController.GetAllUserAddresses();
            //Assert
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result);
            var value = okResult.Value as AddressResponse;
            Assert.Equal(_addressFixture.ValidGetAllAddressForOneUserResponse.AddressList!.Count, value!.AddressList!.Count);
        }
    }
}