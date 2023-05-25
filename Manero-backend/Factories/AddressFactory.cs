using Manero_backend.DTOs.Address;
using Manero_backend.Models.Addresses;

namespace Manero_backend.Factories
{
    public static class AddressFactory
    {
        public static AddressEntity CreateEntity() => new();
        public static AddressResponse CreateResponse() => new();
        public static UserAddressEntity CreateUserAddressEntity(int addressId, string userId, bool billingAddress, string tagName) => new()
        {
            Id = Guid.NewGuid(),
            AddressId = addressId,
            Userid = userId,
            BillingAddress = billingAddress,
            TagName = tagName,
            Created = DateTime.Now,
        };
        public static AddressResponse CreateResponse(string statusMessage, bool error) => new()
        {
            StatusMessage = statusMessage,
            Error = error,
            AddressList = ListFactory.CreateAddressResponseList()
        };
        public static AddressResponse CreateResponse(string streetName, string postalCode, string city, string tagName) => new()
        {
            StreetName = streetName,
            PostalCode = postalCode,
            City = city,
            TagName = tagName
        };
        public static AddressResponse CreateResponse(List<AddressResponse> responseList) => new()
        {
            AddressList = responseList
        };

    }
}
