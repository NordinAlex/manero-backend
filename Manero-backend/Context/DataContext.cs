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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductColorEntity>()
               .HasKey(aa => new { aa.ColorEntityId, aa.ProductEntityId });

            modelBuilder.Entity<ProductColorEntity>()
                .HasOne(aa => aa.ColorEntity)
                .WithMany(a => a.ProductColors)
                .HasForeignKey(aa => aa.ColorEntityId);

            modelBuilder.Entity<ProductColorEntity>()
                .HasOne(aa => aa.ProductEntity)
                .WithMany(a => a.Colors)
                .HasForeignKey(aa => aa.ColorEntityId);



            modelBuilder.Entity<ProductSizeEntity>()
                .HasKey(at => new { at.ProductEntityId, at.SizeEntityId });

            modelBuilder.Entity<ProductSizeEntity>()
                .HasOne(at => at.ProductEntity)
                .WithMany(a => a.Sizes)
                .HasForeignKey(at => at.ProductEntityId);

            modelBuilder.Entity<ProductSizeEntity>()
                .HasOne(at => at.Tag)
                .WithMany(t => t.ArticleTags)
                .HasForeignKey(at => at.TagId);
        }
    }
}
