using Manero_backend.Models;
using Manero_backend.Models.CartsEntity;
using Manero_backend.Models.OrderEntities;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
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
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<ProductTagsEntity> ProductTags { get; set; }
        public DbSet<ProductTypeEntity> ProductTypes { get; set; }
        public DbSet<SizeEntity> Sizes { get; set; }
        public DbSet<TagsEntity> Tags { get; set; }
        public DbSet<TypeEntity> Types { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderLineEntity> OrderLines { get; set; }
        public DbSet<ProductItemEntity> ProductItems { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }

        public DbSet<WishlistEntity> Wishlists { get; set; }
        public DbSet<ReviewEntity> Reviews { get; set; }

        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartItemEntity> CartItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Tags and Product relationship
            modelBuilder.Entity<ProductTagsEntity>()
                .HasKey(pt => new { pt.ProductEntityId, pt.TagsEntityId });

            modelBuilder.Entity<ProductTagsEntity>()
                .HasOne(pt => pt.ProductEntity)
                .WithMany(p => p.Tags)
                .HasForeignKey(pt => pt.ProductEntityId);

            modelBuilder.Entity<ProductTagsEntity>()
                .HasOne(pt => pt.TagsEntity)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagsEntityId);

            // Type and Product relationship 
            modelBuilder.Entity<ProductTypeEntity>()
            .HasKey(pt => new { pt.ProductEntityId, pt.TypeEntityId });

            modelBuilder.Entity<ProductTypeEntity>()
                .HasOne(pt => pt.ProductEntity)
                .WithMany(p => p.Type)
                .HasForeignKey(pt => pt.ProductEntityId);

            modelBuilder.Entity<ProductTypeEntity>()
                .HasOne(pt => pt.TypeEntity)
                .WithMany(t => t.ProductTypes)
                .HasForeignKey(pt => pt.TypeEntityId);

            // Product and ProductItem relationship
            modelBuilder.Entity<ProductEntity>()
              .HasMany(p => p.Variants)
              .WithOne(i => i.Product)
              .OnDelete(DeleteBehavior.Cascade);

            // ProductItem and Image relationship
            modelBuilder.Entity<ProductItemEntity>()
             .HasMany(p => p.Images)
             .WithOne(i => i.ProductItemEntity)
             .OnDelete(DeleteBehavior.Cascade);


            //order and productItem relationship

            modelBuilder.Entity<OrderLineEntity>()
                .HasKey(or => new { or.ProductItemId, or.OrderId });

        }
    }
}
