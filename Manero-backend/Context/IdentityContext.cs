using Manero_backend.Models.UserEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Context
{
    public class IdentityContext : IdentityDbContext<UserEntity>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<AddressEntity> Addresses { get; set; }
    }


}
