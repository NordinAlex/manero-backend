using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Manero_backend_tests.Fixtures;
using Microsoft.AspNet.Identity;
using Moq;
using System.Web.Mvc;

namespace Manero_backend_tests.UnitTests
{
    public class AddressService_Tests : IClassFixture<AddressFixture> 
    {
        private IAddressService _addressService;
        private Mock<IAddressRepository> _addressRepository;
        private AddressFixture _addressFixture;
        //private Mock<UserManager<UserEntity>> GetMockUserManager()
        //{
        //    var userStoreMock = new Mock<IUserStore<UserEntity>>();
        //    return new Mock<UserManager<UserEntity>>(
        //    userStoreMock.Object, null, null, null, null, null, null, null, null);
        //}

        //public AddressService_Tests(AddressFixture addressFixture)
        //{
        //    _addressRepository = new Mock<IAddressRepository>();
        //    _userManager = new Mock<UserManager>();
        //    _addressService = new AddressService(_addressRepository.Object);
        //    _addressFixture = addressFixture;
        //}

        //[Fact]
        //public async Task CreateAsync_ShouldCreateNewAddress_AndReturnAddressResponse()
        //{
        //    //Arrange
        //    _addressRepository.Setup(x => x.)
        //}
    }
}
