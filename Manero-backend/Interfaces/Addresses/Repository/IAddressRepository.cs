using Manero_backend.Context;
using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Addresses.Repository
{
    public interface IAddressRepository
    {
        public Task<AddressEntity> CreateAsync(AddressEntity address);

        public Task<AddressEntity> GetAsync(AddressRequest request);

        public Task<UserAddressEntity> GetUserAddressAsync(string userId, int addressId);

    }
}
