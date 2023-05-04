using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
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

        public async Task<AddressEntity> GetAsync(int id)
        {
            try
            {
                return await _identityContext.Addresses.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch
            {
                return null!;
            }
        }
    }
}
