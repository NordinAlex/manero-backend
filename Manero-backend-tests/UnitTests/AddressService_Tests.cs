using Manero_backend.DTOs.Address;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Interfaces.Addresses.Service;
using Manero_backend.Interfaces.Users.Models;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
using Manero_backend.Services;
using Manero_backend_tests.Fixtures;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace Manero_backend_tests.UnitTests
{
    public class AddressService_Tests
    {
        private Mock<Microsoft.AspNetCore.Identity.UserManager<UserEntity>> _userManager;
        private Mock<IAddressRepository> _addressRepositoryMock;
        private AddressService _addressService;

        public AddressService_Tests()
        {
            _addressRepositoryMock = new Mock<IAddressRepository>();
            _userManager = new Mock<Microsoft.AspNetCore.Identity.UserManager<UserEntity>>();
            _addressService = new AddressService(_addressRepositoryMock.Object, _userManager.Object);
        }
        [Fact]
        public async Task InActivateAddressAsync_WithNonExistingUser_ReturnsErrorAddressResponse()
        {

        }
    }
}
