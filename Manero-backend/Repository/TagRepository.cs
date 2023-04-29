using Manero_backend.Context;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly DataContext _context;
        public TagRepository(DataContext context)
        {
            _context = context;
        }

        public Task<IEnumerable<TagsEntity>> GetAllTagAsync()
        {
            throw new NotImplementedException();
        }
    }
}
