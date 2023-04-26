using Manero_backend.Context;
using Manero_backend.Models.UserEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Manero_backend.Services
{
    public class UserService
    {
        private readonly IdentityContext _identitycontext;

        public UserService(IdentityContext identitycontext)
        {
            _identitycontext = identitycontext;
        }

        public async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
        {
            var entity = await _identitycontext.Users.FirstOrDefaultAsync(predicate);
            return entity!;
        }
    }
}
