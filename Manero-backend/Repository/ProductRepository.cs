using Manero_backend.Context;
using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Manero_backend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> AddAsync(ProductEntity product)
        {

            if (product != null)
            {

                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            return null!;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ProductEntity>> GetAllAsync()
        {
            return await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).Include(p => p.Category).Include(c => c.Category).Include(c => c.Variants).ToListAsync();
        }

        public async Task<ProductEntity> GetByIdAsync(int id)
        {
            var product = await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).Include(p => p.Variants).FirstOrDefaultAsync(a => a.Id == id);
            return product!;
        }

        public async Task<IEnumerable<ProductEntity>> GetByTypeIdAsync(int TypeId)
        {
            var product = await _context.Products.Include(a => a.BrandEntity).Include(z => z.ReviewEntity).Include(p => p.Tags).Include(c => c.Type).ToListAsync();
            return product!;
        }

        public async Task UpdateAsync(ProductEntity product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductEntity>> GetBySearchAsync(Expression<Func<ProductEntity, bool>> predicate)
        {
            return await _context.Products
                                 .Include(a => a.BrandEntity)
                                 .Include(z => z.Category)
                                 .Include(p => p.Tags)
                                 .Include(c => c.Type)
                                 .Include(p => p.Variants)
                                 .Where(predicate)
                                 .ToListAsync();
        }
        public async Task<IEnumerable<ProductEntity>> SearchAndFilterAsync(SearchFilterRequest filter)
        {

            // Baslinje för sökning
            var products = _context.Products
                .Include(a => a.BrandEntity)
                .Include(p => p.Type)?
                .Include(c => c.Tags)?
                .Include(p => p.Category)
                .Include(c => c.Variants).ThenInclude(v => v.Size)
                .Include(c => c.Variants).ThenInclude(v => v.Color)
                .Include(c => c.Variants).ThenInclude(v => v.Images)
                .AsQueryable();

            //// Filtrering på Color
            //if (filter.ImageName != null && filter.ImageName.Any())
            //{
            //    products = products?.Where(p => p.Variants.Any(v => v.Images. == filter.ImageName));
            //}
            // Filtrering på namn
            if (!string.IsNullOrEmpty(filter.Name))
            {
                products = products?.Where(p => p.Name.Contains(filter.Name));
            }

            // Filtrering på SKU
            if (!string.IsNullOrEmpty(filter.SKU))
            {
                var sku = filter.SKU?.ToLower();
                products = products?.Where(p => p.Variants.Any(v => v.SKU.ToLower() == sku));
            }

            // Filtrering på Brand
            if (!string.IsNullOrEmpty(filter.Brand))
            {
                products = products?.Where(p => p.BrandEntity.BrandName == filter.Brand);
            }

            // Filtrering på Category
            if (!string.IsNullOrEmpty(filter.Category))
            {
                products = products?.Where(p => p.Category.Name == filter.Category);
            }

            // Filtrering på Tags
            if (filter.Tags != null && filter.Tags.Any())
            {
                products = products?.Where(p => p.Tags.Any(t => filter.Tags.Contains(t.TagsEntity.Tag.ToLower())));
            }

            // Filtrering på Type
            if (filter.Type != null && filter.Type.Any())
            {
                products = products?.Where(p => p.Type.Any(t => filter.Type.Contains(t.TypeEntity.Type.ToLower())));
            }
            // Filtrering på Color
            if (filter.Color.Any())
            {
                products = products?.Where(p => p.Variants.Any(v => filter.Color.Contains(v.Color.Color)));
            }
            // Filtrering på Size
            if (!string.IsNullOrEmpty(filter.Size))
            {
                products = products?.Where(p => p.Variants.Any(v => v.Size.Size == filter.Size));
            }

            // Filtrering Price
            if (filter.MinPrice.HasValue || filter.MaxPrice.HasValue)
            {
                products = products?.Where(p => p.Variants.Any(v =>
                    (!filter.MinPrice.HasValue || v.Price >= filter.MinPrice.Value) &&
                    (!filter.MaxPrice.HasValue || v.Price <= filter.MaxPrice.Value)));
            }

            var productList = await products.ToListAsync();

            ////Ta bort de varianter som inte matchar filtret
            //foreach (var product in productList)
            //{
            //    var colors = filter.Color?.Select(c => c.ToLower());
            //    var size = filter.Size?.ToLower();
            //    var sku = filter.SKU?.ToLower();

            //    product.Variants = product.Variants.Where(v =>
            //        (colors == null || colors.Contains(v.Color.Color.ToLower())) &&
            //        (size == null || v.Size.Size.ToLower() == size) &&
            //        (sku == null || v.SKU.ToLower() == sku) &&
            //        (!filter.MinPrice.HasValue || v.Price >= filter.MinPrice.Value) &&
            //        (!filter.MaxPrice.HasValue || v.Price <= filter.MaxPrice.Value)).ToList();
            //}

            return productList;
        }

    }
}
