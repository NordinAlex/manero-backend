using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;

namespace Manero_backend.Factories
{
    public static class AddressFactory
    {
        public static AddressEntity CreateEntity() => new();
        public static AddressResponse CreateResponse() => new();

        public static AddressResponse CreateResponse(string statusMessage, bool error) => new()
        {
            StatusMessage = statusMessage,
            Error = error
        };
        
    }
}
