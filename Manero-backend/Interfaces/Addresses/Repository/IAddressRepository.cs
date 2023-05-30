using Manero_backend.Context;
using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;

namespace Manero_backend.Interfaces.Addresses.Repository
{
    public interface IAddressRepository
    {
        public Task<AddressEntity> CreateAddressAsync(AddressEntity address);

        public Task<AddressEntity> GetAddressAsync(AddressRequest request);

        public Task<UserAddressEntity> GetUserAddressAsync(string userId, int addressId);
        public Task<List<AddressResponse>> GetAllUserAddressesAsync(string userId);
        public Task<UserAddressEntity> CheckBillingTrueAsync(string userId);

        public Task<UserAddressEntity> UpdateUserAddressAsync(UserAddressEntity userAddressEntity);
        public Task<UserAddressEntity> CreateUserAddressAsync(UserAddressEntity address);

    }
}
