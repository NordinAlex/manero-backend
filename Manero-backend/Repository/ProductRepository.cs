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

        public async Task AddAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
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



        public async Task<List<ProductEntity>> GetBySearchAndFilterAsync(SearchFilterCriteria criteria)
        {
            IQueryable<ProductEntity> query = _context.Products
                                        .Include(x => x.Variants)
                                        .Include(x => x.Type)
                                         .Include(x => x.Tags)
                                         .Include(x => x.Category)
                                         .Include(x => x.BrandEntity);


            if (!string.IsNullOrWhiteSpace(criteria.Name))
            {
                query = query.Where(p => p.Name.Contains(criteria.Name));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Color))
            {
                query = query.Where(p => p.Variants.Any(v => v.Color.Color.Contains(criteria.Color)));
            }

            //if (criteria.Color != null && criteria.Color.Any())
            //{
            //    query = query.Where(p => p.Variants.Any(v => v.Color.Color.Contains(v.Color.Color)));

            //}


            if (!string.IsNullOrWhiteSpace(criteria.SKU))
            {
                query = query.Where(p => p.Variants.Any(v => v.SKU.Contains(criteria.SKU)));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Size))
            {
                query = query.Where(p => p.Variants.Any(v => v.Size.Size.Contains(criteria.Size)));
            }

            if (criteria.MinPrice.HasValue)
            {
                var minPrice = criteria.MinPrice.Value;
                query = query.Where(p => p.Variants.Any(v => v.Price >= minPrice));
            }

            if (criteria.MaxPrice.HasValue)
            {
                var maxPrice = criteria.MaxPrice.Value;
                query = query.Where(p => p.Variants.Any(v => v.Price <= maxPrice));
            }

            if (criteria.Type != null && criteria.Type.Any())
            {
                query = query.Where(p => p.Type.Any(t => criteria.Type.Contains(t.TypeEntity.Type)));
            }

            if (criteria.Tags != null && criteria.Tags.Any())
            {
                query = query.Where(p => p.Tags.Any(t => criteria.Tags.Contains(t.TagsEntity.Tag)));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Category))
            {
                query = query.Where(p => p.Category.Name.Contains(criteria.Category));
            }

            if (!string.IsNullOrWhiteSpace(criteria.Brand))
            {
                query = query.Where(p => p.BrandEntity.BrandName.Contains(criteria.Brand));
            }


            return await query.ToListAsync();
        }

    }
}
