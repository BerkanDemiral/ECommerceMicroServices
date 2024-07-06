using ECommerceWeb.Catalog.Dtos.ProductDetailDtos;
using ECommerceWeb.Catalog.Dtos.ProductDtos;

namespace ECommerceWeb.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetailDto(string id);
    }
}
