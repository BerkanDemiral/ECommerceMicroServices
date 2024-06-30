using AutoMapper;
using ECommerceWeb.Catalog.Dtos.CategoryDtos;
using ECommerceWeb.Catalog.Dtos.ProductDetailDtos;
using ECommerceWeb.Catalog.Dtos.ProductDtos;
using ECommerceWeb.Catalog.Dtos.ProductImageDto;
using ECommerceWeb.Catalog.Entities;

namespace ECommerceWeb.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Category, ResultCategoryDto> ().ReverseMap();
            CreateMap<Category, CreateCategoryDto> ().ReverseMap();
            CreateMap<Category, UpdateCategoryDto> ().ReverseMap();
            CreateMap<Category, GetByIdCategoryDto> ().ReverseMap();

            CreateMap<Product, ResultProductDto>().ReverseMap();
            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, GetByIdProductDto>().ReverseMap();

            CreateMap<ProductDetail, ResultProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, CreateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, UpdateProductDetailDto>().ReverseMap();
            CreateMap<ProductDetail, GetByIdProductDetailDto>().ReverseMap();

            CreateMap<ProductImage, ResultProductImageDto>().ReverseMap();
            CreateMap<ProductImage, CreateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, UpdateProductImageDto>().ReverseMap();
            CreateMap<ProductImage, GetByIdProductImageDto>().ReverseMap();


        }
    }
}
