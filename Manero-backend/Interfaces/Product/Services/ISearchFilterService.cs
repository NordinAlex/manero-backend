using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface ISearchFilterService
    {
        Task<IEnumerable<SearchFilterResponse>> SearchAndFilterAsync(SearchFilterRequest filter);
        Task<IEnumerable<TagResponse>> GetAllTagAsync();
        Task<IEnumerable<BrandResponse>> GetAlBrandAsync();
        Task<IEnumerable<ColorResponse>> GetAllColorAsync();
        Task<IEnumerable<TypeResponse>> GetAllTypeAsync();
        Task<IEnumerable<CategoryResponse>> GetAllCategoryAsync();
        Task<IEnumerable<SizeResponse>> GetAllSizeAsync();
    }
}
