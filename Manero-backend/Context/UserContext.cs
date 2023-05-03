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

        /*
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var roleId = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "Admin",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "user",
                    NormalizedName = "User",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );

            var passwordHasher = new PasswordHasher<UserEntity>();
            builder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = userId,
                UserName = "administrator@domain.com",
                Email = "administrator@domain.com",
                PasswordHash = passwordHasher.HashPassword(null!, "BytMig123!"),
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = userId
            });
        }
        */
    }
}
