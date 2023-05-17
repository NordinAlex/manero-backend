using Manero_backend.Context;
using Manero_backend.DTOs.User;
using Manero_backend.Interfaces.Users.Repositories;
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

        public Task<UserResponse> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task SaveDBAsync()
        {
            try
            {
                await _identityContext.SaveChangesAsync();
            }
            catch
            {  }
        }
    }
}
