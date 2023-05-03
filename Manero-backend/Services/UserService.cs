using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.DTOs.User;
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

        public async Task<UserEntity> Create(UserEntity userEntity)
        {
            _identitycontext.Add(userEntity);
            await _identitycontext.SaveChangesAsync();
            return userEntity;
        }

        public async Task<SignUpResponse> GetAsync(int id)
        {
            var entity = await _identitycontext.Users.FirstOrDefaultAsync();
            return entity!;
        }
    }
}
