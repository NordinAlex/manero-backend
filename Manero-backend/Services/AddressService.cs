using Manero_backend.DTOs.Address;
using Manero_backend.Interfaces.Addresses.Service;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Services
{
    public class AddressService : IAddressService
    {
        public async Task<AddressResponse> CreateAddressAsync(AddressRequest request)
        {

            return null!; 
        }
        public async Task<AddressResponse> GetAllForOneUserAsync(string email)
        {

            return null!;
        }
        public async Task<AddressResponse> RemoveAddressFromUser(AddressRequest request)
        {
            return null!;
        }
    }
}
