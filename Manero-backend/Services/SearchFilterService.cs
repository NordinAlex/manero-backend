using Manero_backend.DTOs.Product;
using Manero_backend.Interfaces.Product;
using Manero_backend.Interfaces.Product.Repositories;
using Manero_backend.Interfaces.Product.Services;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Repository;
using System.Web.Mvc;

namespace Manero_backend.Services
{
    public class SearchFilterService : ISearchFilterService
    {
        private readonly IProductRepository _productRepository;
        private readonly IBrandRepository _brandRepository;
        private readonly IColorRepository _colorRepository;
        private readonly IImageRepository _imageRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly ITagRepository _tagRepository;
        private readonly ITypeRepository _typeRepository;
        private readonly IProductItemRepository _productItemRepository;
        private readonly ICategoryRepository _categoryRepository;


        public SearchFilterService(IProductRepository productRepository, ITagRepository tagRepository, ITypeRepository typeRepository, IBrandRepository brandRepository, IColorRepository colorRepository, IImageRepository imageRepository, ISizeRepository sizeRepository, IProductItemRepository productItemRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _typeRepository = typeRepository;
            _brandRepository = brandRepository;
            _colorRepository = colorRepository;
            _imageRepository = imageRepository;
            _sizeRepository = sizeRepository;
            _productItemRepository = productItemRepository;
            _categoryRepository = categoryRepository;
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
                    Color = new List<string> { v.Color.Color },
                    ImageName = GetImageNames(v.Images!)
                    
                }).ToList()
            });
            var tags = await _tagRepository.GetAllTagAsync();
            var types = await _typeRepository.GetAllTypeAsync();
            return filterResponses;
        }

        private List<string> GetImageNames(ICollection<ImagesEntity> images)
        {
            var imageNames = new List<string>();
            foreach (var image in images)
            {
                imageNames.Add(image.ImageName!);
            }
            return imageNames;
        }


        public async Task<IEnumerable<TagResponse>> GetAllTagAsync()
        {
            var tags = await _tagRepository.GetAllTagAsync();
            var tagResponse = tags.Select(p => new TagResponse
            {

                Name = p.Tag,
            });
            return tagResponse;
        }
        public async Task<IEnumerable<BrandResponse>> GetAlBrandAsync()
        {
            var b = await _brandRepository.GetAllBrandAsync();
            var bResponse = b.Select(p => new BrandResponse
            {

                Name = p.BrandName,
            });
            return bResponse;
        }
        public async Task<IEnumerable<CategoryResponse>> GetAllCategoryAsync()
        {
            var c = await _categoryRepository.GetAllCategoryAsync();
            var cResponse = c.Select(p => new CategoryResponse
            {

                Name = p.Name,
            });
            return cResponse;
        }
        public async Task<IEnumerable<SizeResponse>> GetAllSizeAsync()
        {
            var s = await _sizeRepository.GetAllSizeAsync();
            var sResponse = s.Select(p => new SizeResponse
            {

                Name = p.Size,
            });
            return sResponse;
        }
        public async Task<IEnumerable<ColorResponse>> GetAllColorAsync()
        {
            var c = await _colorRepository.GetAllColorAsync();
            var cResponse = c.Select(p => new ColorResponse
            {

                Name = p.Color,
            });
            return cResponse;
        }

        public async Task<IEnumerable<TypeResponse>> GetAllTypeAsync()
        {
            var c = await _typeRepository.GetAllTypeAsync();
            var cResponse = c.Select(p => new TypeResponse
            {

                Name = p.Type,
            });
            return cResponse;
        }
    }
}
