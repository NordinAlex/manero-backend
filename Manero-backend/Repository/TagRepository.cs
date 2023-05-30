using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;
using Microsoft.EntityFrameworkCore;

namespace Manero_backend.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TagsEntity>> GetAllTagAsync()
        {
            return await _context.Tags.ToListAsync();
        }
        public async Task<IEnumerable<TagsEntity>> GetTagsForProduct(int productId)
        {
            return await _context.ProductTags
                .Where(pt => pt.ProductEntityId == productId)
                .Select(pt => pt.TagsEntity)
                .ToListAsync();
        }

    }
}
