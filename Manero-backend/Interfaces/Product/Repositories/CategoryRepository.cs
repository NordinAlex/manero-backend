using Manero_backend.Context;

namespace Manero_backend.Interfaces.Product.Repositories
{
    public class CategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        //public async Task<ServiceResponse<List<Category>>> GetCategories()
        //{
        //    var categories = await _context.Categories.ToListAsync();
        //    return new ServiceResponse<List<Category>>
        //    {
        //        Data = categories
        //    };
        //}
    }
}
