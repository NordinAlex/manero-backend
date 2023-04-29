using Azure;
using Manero_backend.DTOs.Product;
using Manero_backend.Models.ProductEntities;

namespace Manero_backend.Models
{
    public static class EntityDTOMapper
    {
        public static ProductResponse ToProductResponse(this ProductEntity product,
            IEnumerable<BrandEntity> brands, IEnumerable<ColorEntity> colors, IEnumerable<ImagesEntity> images,
            IEnumerable<SizeEntity> sizes, IEnumerable<TagsEntity> tags, IEnumerable<TypeEntity> types)
        {
            return new ProductResponse
            {

            };
        }
        public static ProductEntity ToProductEntity(this ProductRequest request)
        {

            return new ProductEntity
            {


            };
        }

        public static void UpdateProductEntity(this ProductRequest request, ProductEntity entity)
        {

        }
    }
}
