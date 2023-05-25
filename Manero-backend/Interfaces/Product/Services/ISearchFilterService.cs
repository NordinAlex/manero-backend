using Manero_backend.DTOs.Product;

namespace Manero_backend.Interfaces.Product.Services
{
    public interface ISearchFilterService
    {
        Task<IEnumerable<SearchFilterResponse>> SearchAndFilterAsync(SearchFilterRequest filter);
    }
}
