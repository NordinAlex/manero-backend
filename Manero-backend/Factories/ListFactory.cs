using Manero_backend.DTOs.Address;
using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Factories
{
    public static class ListFactory
    {
        public static List<AddressResponse> CreateAddressResponseList() { return new List<AddressResponse>(); }
    }
   
}
