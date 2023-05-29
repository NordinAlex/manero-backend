using Manero_backend.Controllers;
using Manero_backend.Interfaces.Addresses.Service;
using Moq;
using Manero_backend_tests.Fixtures;
using Microsoft.AspNetCore.Mvc;
using Manero_backend.DTOs.Address;
using Manero_backend.Migrations;

namespace Manero_backend_tests.UnitTests
{
    public class AddressController_Tests : IClassFixture<AddressFixture>
    {

        private AddressController _controller;
        private Mock<IAddressService> _addressService;
        private AddressFixture _addressFixture;

        public AddressController_Tests(AddressFixture addressFixture)
        {
            _addressService = new Mock<IAddressService>();
            _controller = new AddressController(_addressService.Object);
            _addressFixture = addressFixture;
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateNewAddress_AndReturnAddressResponse()
        {
            //Arrange
            _addressService.Setup(x => x.CreateAddressAsync(_addressFixture.ValidAddressCreateRequest)).ReturnsAsync(_addressFixture.ValidAddressCreateResponse);

            //Act
            var result = await _controller.CreateAsync(_addressFixture.ValidAddressCreateRequest);

            //Assert
            Assert.NotNull(result);
        }
    }
}