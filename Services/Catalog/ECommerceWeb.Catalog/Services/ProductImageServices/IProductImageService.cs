using ECommerceWeb.Catalog.Dtos.ProductDtos;
using ECommerceWeb.Catalog.Dtos.ProductImageDto;

namespace ECommerceWeb.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageDto(string id);
    }
}
