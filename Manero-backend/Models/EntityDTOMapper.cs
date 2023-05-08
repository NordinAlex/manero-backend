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
                Description = product.Description,
                Brand = brands.FirstOrDefault(a => a.Id == product.BrandEntityId)?.BrandName,                
                Tags = product.Tags?.Select(pt => tags.FirstOrDefault(t => t.Id == pt.TagsEntityId)?.Tag).ToList() ?? new List<string>(),
                Type = product.Type?.Select(pty => types.FirstOrDefault(ty => ty.Id == pty.TypeEntityId)?.Type).ToList() ?? new List<string>(),
            };
        }
        public static ProductEntity ToProductEntity(this ProductRequest request)
        {
            var ProductTagsEntity = request.TagsIds.Select(TagId => new ProductTagsEntity { TagsEntityId = TagId }).ToList();           
            var ProductTypeEntity = request.TypeIds.Select(tId => new ProductTypeEntity { TypeEntityId = tId }).ToList();
         
            return new ProductEntity
            {
                Name = request.Name,               
                BrandEntityId = request.BrandId,
                //WishlistEntityId = request.WishlistEntityId,
                Tags = ProductTagsEntity,
             
                Type = ProductTypeEntity,



            };
        }

        public static void UpdateProductEntity(this ProductRequest request, ProductEntity entity)
        {
            entity.Name = request.Name;            
            entity.Description = request.Description;
            
            entity.BrandEntityId = request.BrandId;
            //entity.WishlistEntityId = request.WishlistEntityId;            

        }
    }
}
