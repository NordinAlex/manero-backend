using Manero_backend.DTOs.Address;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Manero_backend_tests.Fixtures;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;

namespace Manero_backend_tests.UnitTests
{
    public class AddressService_Tests : IClassFixture<AddressFixture>
    {
        //private IAddressService _addressService;
        //private Mock<IAddressRepository> _addressRepository;
        //private AddressFixture _addressFixture;
        //private UserManager<UserEntity> _userManager;

        //public AddressService_Tests(AddressFixture addressFixture)
        //{
        //    var userStoreMock = new Mock<IUserStore<UserEntity>>();
        //    userStoreMock.As<IQueryableUserStore<UserEntity>>();
        //    userStoreMock.As<IAsyncQueryProvider>(); // Lägg till denna rad för att implementera IAsyncQueryProvider

        //    // Skapa en instans av UserManager och använd mockobjektet som userStore
        //    _userManager = new UserManager<UserEntity>(userStoreMock.Object, null, null, null, null, null, null, null, null);


        //    _addressRepository = new Mock<IAddressRepository>();
        //    _addressService = new AddressService(_addressRepository.Object, _userManager);
        //    _addressFixture = addressFixture;
        //}
        //[Fact]
        //public async Task CreateAsync_ShouldCreateNewAddress_AndReturnAddressResponse()
        //{
        //    // Arrange
        //    _addressRepository.Setup(x => x.CreateUserAddressAsync(_addressFixture.ValidUserAddressEntity)).ReturnsAsync(_addressFixture.ValidUserAddressEntity);

        //    // Act
        //    var result = await _addressService.CreateAddressAsync(_addressFixture.ValidAddressCreateRequest);

        //    // Assert
        //    Assert.NotNull(result);
        //}
    }
}