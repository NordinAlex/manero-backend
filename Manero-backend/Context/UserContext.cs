using Manero_backend.Models.UserEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddressEntity> Addresses { get; set; }
        public DbSet<UserAddressEntity> UserAddresses { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<UserCompanyEntity> CompanyAddresses { get; set; }


    }
}
