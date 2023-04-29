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
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Quantity = product.Quantity,
                SKU = product.SKU,
                BrandEntityId = product.BrandEntityId,
                BrandEntity = brands.FirstOrDefault(a => a.Id == product.BrandEntityId)?.BrandName,
                WishlistEntityId = product.WishlistEntityId,
              
              

            };
        }
        public static ProductEntity ToProductEntity(this ProductRequest request, ProductEntity product)
        {

            var ProductColorEntity = request.ColorsIds.Select(colorId => new ProductColorEntity { ColorEntityId = colorId }).ToList();
            return new ProductEntity
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity,
                SKU = request.SKU,
                BrandEntityId = request.BrandEntityId,
                WishlistEntityId = request.WishlistEntityId,
             


            };
        }

        public static void UpdateProductEntity(this ProductRequest request, ProductEntity entity)
        {
            entity.Name = request.Name;
            entity.Price = request.Price;
            entity.Description = request.Description;
            entity.Quantity = request.Quantity;
            entity.SKU = request.SKU;
            entity.BrandEntityId = request.BrandEntityId;
            entity.WishlistEntityId = request.WishlistEntityId;            

        }
    }
}
