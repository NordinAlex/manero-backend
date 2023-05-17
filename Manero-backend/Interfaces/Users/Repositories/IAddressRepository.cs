using Manero_backend.Context;
using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Users.Repositories
{
    public interface IAddressRepository
    {
        public Task<AddressEntity> CreateAsync(AddressEntity address);

        public Task<AddressEntity> GetAsync(int id);

    }
}
