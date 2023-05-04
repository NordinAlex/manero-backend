using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IdentityContext _identityContext;

        public UserRepository(IdentityContext identityContext)
        {
            _identityContext = identityContext;
        }

        public async Task<bool> CheckAsync()
        {
             return await _identityContext.Users.AnyAsync();
        }

        public async Task<UserEntity> CreateAsync(UserEntity entity)
        {
            try
            {
                _identityContext.Add(entity);
                await _identityContext.SaveChangesAsync();

                return entity;
            }
            catch
            {
                return null!;
            }
        }
    }
}
