using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.UserProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BrandEntity> Brands { get; set; }
        public DbSet<ColorEntity> Colors { get; set; }
        public DbSet<ImagesEntity> Images { get; set; }
        public DbSet<ProductColorEntity> ProductColors { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductSizeEntity> ProductSizes { get; set; }
        public DbSet<ProductTagsEntity> ProductTags { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<TagsEntity> Tags { get; set; }
        public DbSet<TypeEntity> Types { get; set; }


        public DbSet<WishlistEntity> Wishlists { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }        

    }
}
