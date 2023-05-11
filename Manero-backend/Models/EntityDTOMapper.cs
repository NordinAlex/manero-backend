using Azure;
using Manero_backend.DTOs.Product;
using Manero_backend.Migrations;
using Manero_backend.Models.ProductEntities;
using Manero_backend.Models.ProductItemEntities;
using System.Drawing;
using static System.Net.Mime.MediaTypeNames;

namespace Manero_backend.Models
{
    public static class EntityDTOMapper
    {
        public static ProductResponse ToProductResponse(this ProductEntity product, IEnumerable<TagsEntity> tags, IEnumerable<BrandEntity> brands, IEnumerable<ColorEntity> colors, IEnumerable<ImagesEntity> images, IEnumerable<SizeEntity> sizes, IEnumerable<TypeEntity> types)
        {
            if (product == null)
            {
                return null!;
            }
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                //Brand = product.BrandEntity.BrandName,
                Category = product.Category?.Name,
                Brand = brands.First(b => b.Id == product.BrandEntityId).BrandName,
                Tags = product.Tags.Select(t => tags.First(tag => tag.Id == t.TagsEntityId).Tag).ToList(),
                //Type = product.Type.Select(t => product.Type.First(type => type.ProductEntityId == t.TypeEntityId).TypeEntity.Type).ToList(),
                Type = product.Type.Select(t => types.First(type => type.Id == t.TypeEntityId).Type).ToList(),

                Variants = product.Variants.Select(v => v.ToProductItemResponse()).ToList(),
                
            };

        }
        public static ProductItemResponse ToProductItemResponse(this ProductItemEntity productItemEntity)
        {
            return new ProductItemResponse
            {
                Id = productItemEntity.Id,
                SKU = productItemEntity.SKU,
                Color = productItemEntity.Color.Color,
                Size = productItemEntity.Size.Size,
                Price = productItemEntity.Price,
                Stock = productItemEntity.QuantityInStock,
                ImageAlt = productItemEntity.Images?.Select(i => i.ImageAlt).ToList(),
                ImageName = productItemEntity.Images?.Select(i => i.ImageName).ToList(),
            };
        }


        public static ProductEntity ToProductEntity(this ProductRequest request)
        {
            var ProductTagsEntity = request.TagsId.Select(TagId => new ProductTagsEntity { TagsEntityId = TagId }).ToList();
            var ProductTypeEntity = request.TypeId.Select(tId => new ProductTypeEntity { TypeEntityId = tId }).ToList();
            //var ProductBrandEntity =  new BrandEntity { Id = request.BrandId, BrandName = new BrandEntity().BrandName}.Id;

            return new ProductEntity
            {
                Name = request.Name,
                BrandEntityId = request.BrandId,
                Description = request.Description,
                CategoryEntityId = request.CategoryId,
                //WishlistEntityId = request.WishlistEntityId,
                Tags = ProductTagsEntity,
                Type = ProductTypeEntity,
                //BrandEntityId = ProductBrandEntity,
                //BrandEntity = new BrandEntity { BrandName = request.Brand , BrandCode = request.BrandCode },
                //Variants = request.Variants.Select(v => new ProductItemEntity
                //{

                //    Color = new ColorEntity { Color = v.Color },
                //    Size = new SizeEntity { Size = v.Size },
                //    Price = v.Price,
                //    QuantityInStock = v.Stock,
                //    SKU = $"{request.Name}-{v.Color}-{v.Size}",
                //    //Images = v.ImageName.Zip(v.ImageAlt, (name, alt) => new ImagesEntity { ImageName = name, ImageAlt = alt }).ToList(),
                //}).ToList(),
            };


        }



        public static void UpdateProductEntity(this ProductRequest request, ProductEntity entity)
        {
            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.CategoryEntityId = request.CategoryId;
            entity.BrandEntityId = request.BrandId;
            //entity.BrandEntity.BrandName = request.Brand;
            //entity.WishlistEntityId = request.WishlistEntityId;            

        }
    }
}
