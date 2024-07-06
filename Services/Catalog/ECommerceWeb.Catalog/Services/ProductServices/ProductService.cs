using AutoMapper;
using ECommerceWeb.Catalog.Dtos.ProductDtos;
using ECommerceWeb.Catalog.Entities;
using ECommerceWeb.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerceWeb.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString); // client tanımı yapıldı ****
            var database = client.GetDatabase(databaseSettings.DatabaseName); // db tanımı alındı *****
            _productCollection = database.GetCollection<Product>(databaseSettings.CategoryCollectionName); // db'deki karşığı olan Products alındı...
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var value = _mapper.Map<Product>(createProductDto); // aslında mapping işlemi aşağıdaki kod içinde de yedirilebilir. 
            await _productCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductAsync(string id) // SADECE DELETE İŞLEMİNDE MAPPİNG İŞLEMİNE GEREK YOKTUR UNUTMA !!!
        {
            await _productCollection.DeleteOneAsync(id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x=>true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find<Product>(x=>x.ProductId == id).ToListAsync(); // veriyi önce entity içerisinde buluyoruz.
            return _mapper.Map<GetByIdProductDto>(values); // sonra bulduğumuz veriyi mapliyoruz.
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId,value);

        }
    }
}
