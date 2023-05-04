using Manero_backend.Models.UserEntities;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public interface IUserRepository
    {
        public Task<bool> CheckAsync();

        public Task<UserEntity> CreateAsync(UserEntity entity);
    }
}
