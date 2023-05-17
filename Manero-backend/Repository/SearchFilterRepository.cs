//using Manero_backend.Context;
//using Manero_backend.DTOs.Product;
//using Manero_backend.Models.ProductEntities;
//using Microsoft.EntityFrameworkCore;

//namespace Manero_backend.Repository
//{
//    public class SearchFilterRepository
//    {
//        private readonly DataContext _context;
//        public SearchFilterRepository(DataContext context)
//        {
//            _context = context;
//        }
//        public async Task<List<ProductEntity>> GetBySearchAndFilterAsync(SearchFilterCriteria criteria)
//        {
//            IQueryable<ProductEntity> query = _context.Products.Include(x=>x.Variants);

//            if (!string.IsNullOrWhiteSpace(criteria.Name))
//            {
//                query = query.Where(p => p.Name.Contains(criteria.Name));
//            }

//            if (!string.IsNullOrWhiteSpace(criteria.Color))
//            {
//                query = query.Where(p => p.Variants.Any(v => v.Color.Color.Contains(criteria.Color)));
//            }

//            if (!string.IsNullOrWhiteSpace(criteria.SKU))
//            {
//                query = query.Where(p => p.Variants.Any(v => v.SKU.Contains(criteria.SKU)));
//            }

//            if (!string.IsNullOrWhiteSpace(criteria.Size))
//            {
//                query = query.Where(p => p.Variants.Any(v => v.Size.Size.Contains(criteria.Size)));
//            }

//            if (criteria.MinPrice.HasValue)
//            {
//                query = query.Where(p => p.Variants.Any(v => v.Price >= criteria.MinPrice));
//            }

//            if (criteria.MaxPrice.HasValue)
//            {
//                query = query.Where(p => p.Variants.Any(v => v.Price <= criteria.MaxPrice));
//            }


//            return await query.ToListAsync();
//        }

//    }
//}
