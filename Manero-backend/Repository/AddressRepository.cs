using Azure.Core;
using Manero_backend.Context;
using Manero_backend.DTOs.Address;
using Manero_backend.Interfaces.Addresses.Repository;
using Manero_backend.Models.Addresses;
using Manero_backend.Models.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly IdentityContext _identityContext;

        public AddressRepository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public async Task<AddressEntity> CreateAsync(AddressEntity address)
        {
            try
            {
                _identityContext.Addresses.Add(address);
                await _identityContext.SaveChangesAsync();
                return address;
            } catch
            {
                return null!;
            }
          
        }

        public async Task<AddressEntity> GetAsync(AddressRequest request)
        {
            try
            {
                return await _identityContext.Addresses.FirstOrDefaultAsync(x => x.StreetName == request.StreetName && x.PostalCode == request.PostalCode && x.City == request.City)?? null!;
            }
            catch
            {
                return null!;
            }
        }

        public async Task<UserAddressEntity> GetUserAddressAsync(string userId, int addressId)
        {
            try
            {
                return await _identityContext.UserAddress.FirstOrDefaultAsync(x => x.Userid == userId && x.AddressId == addressId) ?? null!;
            }
            catch
            {
                return null!;
            }
        }
    }
}
