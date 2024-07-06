using AutoMapper;
using ECommerceWeb.Catalog.Dtos.ProductDetailDtos;
using ECommerceWeb.Catalog.Dtos.ProductDtos;
using ECommerceWeb.Catalog.Entities;
using ECommerceWeb.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerceWeb.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMongoCollection<ProductDetail> _productDetailCollection;
        private readonly IMapper _mapper;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // client tanımı yapıldı ****
            var database = client.GetDatabase(databaseSettings.DatabaseName); // db tanımı alındı *****
            _productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.CategoryCollectionName); // db'deki karşığı olan Products alındı...
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(createProductDetailDto); // aslında mapping işlemi aşağıdaki kod içinde de yedirilebilir. 
            await _productDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailDto(string id)
        {
            var values = await _productDetailCollection.Find<ProductDetail>(x => x.ProductDetailId == id).ToListAsync(); // veriyi önce entity içerisinde buluyoruz.
            return _mapper.Map<GetByIdProductDetailDto>(values); // sonra bulduğumuz veriyi mapliyoruz.
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            var value = _mapper.Map<ProductDetail>(updateProductDetailDto);
            await _productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, value);
        }
    }
}
