using Azure;
using Manero_backend.DTOs.Product;
using Manero_backend.Models.ProductEntities;
using static System.Net.Mime.MediaTypeNames;

namespace Manero_backend.Models
{
    public static class EntityDTOMapper
    {
        public static ProductResponse ToProductResponse(this ProductEntity product, IEnumerable<TagsEntity> tags, IEnumerable<BrandEntity> brands, IEnumerable<ColorEntity> colors, IEnumerable<ImagesEntity> images,IEnumerable<SizeEntity> sizes,  IEnumerable<TypeEntity> types)
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
                //WishlistEntityId = product.WishlistEntityId,

                Colors = product.Colors?.Select(pc => colors.FirstOrDefault(c => c.Id == pc.ColorEntityId)?.Color).ToList() ?? new List<string>(),
                Sizes = product.Sizes?.Select(ps => sizes.FirstOrDefault(s => s.Id == ps.SizeEntityId)?.Size).ToList() ?? new List<string>(),
                Tags = product.Tags?.Select(pt => tags.FirstOrDefault(t => t.Id == pt.TagsEntityId)?.Tag).ToList() ?? new List<string>(),
                Type = product.Type?.Select(pty => types.FirstOrDefault(ty => ty.Id == pty.TypeEntityId)?.Type).ToList() ?? new List<string>(),
            };
        }
        public static ProductEntity ToProductEntity(this ProductRequest request)
        {
            var ProductTagsEntity = request.TagsIds.Select(TagId => new ProductTagsEntity { TagsEntityId = TagId }).ToList();
            var ProductSizeEntity = request.SizesIds.Select(sId => new ProductSizeEntity { SizeEntityId = sId }).ToList();
            var ProductTypeEntity = request.TypeIds.Select(tId => new ProductTypeEntity { TypeEntityId = tId }).ToList();
            var ProductColorEntity = request.ColorsIds.Select(colorId => new ProductColorEntity { ColorEntityId = colorId }).ToList();
            return new ProductEntity
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Quantity = request.Quantity,
                SKU = request.SKU,
                BrandEntityId = request.BrandEntityId,
                //WishlistEntityId = request.WishlistEntityId,
                Tags = ProductTagsEntity,
                Sizes = ProductSizeEntity,
                Colors = ProductColorEntity,
                Type = ProductTypeEntity,



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
            //entity.WishlistEntityId = request.WishlistEntityId;            

        }
    }
}
