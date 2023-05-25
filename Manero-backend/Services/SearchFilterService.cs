using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using System.Web.Mvc;

namespace Manero_backend.Services
{
    public class SearchFilterService : ISearchFilterService
    {
        private readonly IProductRepository _productRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly ITagRepository _tagRepository;

        public SearchFilterService(IProductRepository productRepository, ITagRepository tagRepository, ITypeRepository typeRepository)
        {
            _productRepository = productRepository;           
            _tagRepository = tagRepository;
            _typeRepository = typeRepository;
        }
        public async Task<IEnumerable<SearchFilterResponse>> SearchAndFilterAsync(SearchFilterRequest filter)
        {
            var productEntities = await _productRepository.SearchAndFilterAsync(filter);

            var filterResponses = productEntities.Select(p => new SearchFilterResponse
            {
                Name = p.Name,
                Category = p.Category?.Name,
                Brand = p.BrandEntity?.BrandName,
                //Tags = p.Tags.Select(t => t.TagsEntity.Tag)?.ToList(),
                Type = p.Type?.Where(t => t.TypeEntity?.Type != null).Select(t => t.TypeEntity.Type).ToList(),
                Tags = p.Tags?.Where(t => t.TagsEntity?.Tag != null).Select(t => t.TagsEntity.Tag).ToList(),

                Variants = p.Variants.Select(v => new SearchFilterResponse.Variant
                {
                    SKU = v.SKU,
                    Size = v.Size.Size,
                    Price = v.Price,
                    Color = new List<string> { v.Color.Color }
                }).ToList()
            });
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            return filterResponses;
        }
    }
}
