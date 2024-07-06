using AutoMapper;
using ECommerceWeb.Catalog.Dtos.ProductDetailDtos;
using ECommerceWeb.Catalog.Dtos.ProductImageDto;
using ECommerceWeb.Catalog.Entities;
using ECommerceWeb.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerceWeb.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMongoCollection<ProductImage> _productImageCollection;
        private readonly IMapper _mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // client tanımı yapıldı ****
            var database = client.GetDatabase(databaseSettings.DatabaseName); // db tanımı alındı *****
            _productImageCollection = database.GetCollection<ProductImage>(databaseSettings.CategoryCollectionName); // db'deki karşığı olan Products alındı...
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(createProductImageDto); // aslında mapping işlemi aşağıdaki kod içinde de yedirilebilir. 
            await _productImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageDto(string id)
        {
            var values = await _productImageCollection.Find<ProductImage>(x => x.ProductImageId == id).ToListAsync(); // veriyi önce entity içerisinde buluyoruz.
            return _mapper.Map<GetByIdProductImageDto>(values); // sonra bulduğumuz veriyi mapliyoruz.
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var value = _mapper.Map<ProductImage>(updateProductImageDto);
            await _productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, value);
        }
    }
}
