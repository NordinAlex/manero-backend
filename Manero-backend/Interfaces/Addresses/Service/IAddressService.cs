using Manero_backend.DTOs.Address;

namespace Manero_backend.Interfaces.Addresses.Service
{
    public interface IAddressService
    {
        Task<AddressResponse> CreateAddressAsync(AddressRequest request);
        Task<AddressResponse> GetAllForOneUserAsync(string email);
        Task<AddressResponse> RemoveAddressFromUser(AddressRequest request);
    }
}
