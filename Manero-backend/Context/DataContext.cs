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
            // Brand and Product relationship
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


            // Size and Product relationship
            modelBuilder.Entity<ProductSizeEntity>()
                .HasKey(at => new { at.ProductEntityId, at.SizeEntityId });

            modelBuilder.Entity<ProductSizeEntity>()
                .HasOne(at => at.ProductEntity)
                .WithMany(a => a.Sizes)
                .HasForeignKey(at => at.ProductEntityId);

            modelBuilder.Entity<ProductSizeEntity>()
                .HasOne(at => at.SizeEntity)
                .WithMany(t => t.ProductSize)
                .HasForeignKey(at => at.SizeEntityId);


            // Tags and Product relationship
            modelBuilder.Entity<ProductTagsEntity>()
                .HasKey(at => new { at.ProductEntityId, at.TagsEntityId });

            modelBuilder.Entity<ProductTagsEntity>()
                .HasOne(at => at.ProductEntity)
                .WithMany(a => a.Tags)
                .HasForeignKey(at => at.ProductEntityId);

            modelBuilder.Entity<ProductTagsEntity>()
                .HasOne(at => at.TagsEntity)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(at => at.TagsEntityId);

            // Type and Product relationship 
            modelBuilder.Entity<ProductTypeEntity>()
            .HasKey(at => new { at.ProductEntityId, at.TypeEntityId });

            modelBuilder.Entity<ProductTypeEntity>()
                .HasOne(at => at.ProductEntity)
                .WithMany(a => a.Type)
                .HasForeignKey(at => at.ProductEntityId);

            modelBuilder.Entity<ProductTypeEntity>()
                .HasOne(at => at.TypeEntity)
                .WithMany(t => t.ProductTypes)
                .HasForeignKey(at => at.TypeEntityId);
     
        }
    }
}
