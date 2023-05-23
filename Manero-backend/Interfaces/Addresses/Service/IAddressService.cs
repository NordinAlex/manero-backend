using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;

namespace Manero_backend.Interfaces.Addresses.Service
{
    public interface IAddressService
    {
        Task<AddressResponse> CreateAddressAsync(AddressRequest request);
        Task<AddressEntity> GetAsync(AddressRequest request);
        Task<AddressResponse> GetAllForOneUserAsync(string email);
        Task<AddressResponse> InActivateAddressAsync(AddressRequest request);
    }
}
