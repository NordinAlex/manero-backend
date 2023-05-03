using Manero_backend.Context;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class UserRepository
    {
        private readonly UserContext _userContext;

        public UserRepository(UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task CreateAsync(UserEntity user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }
    }
}
