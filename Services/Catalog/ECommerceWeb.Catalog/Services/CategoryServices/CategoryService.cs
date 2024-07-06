using AutoMapper;
using ECommerceWeb.Catalog.Dtos.CategoryDtos;
using ECommerceWeb.Catalog.Entities;
using ECommerceWeb.Catalog.Settings;
using MongoDB.Driver;

namespace ECommerceWeb.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString); // client tanımı yapıldı ****
            var database = client.GetDatabase(_databaseSettings.DatabaseName); // db tanımı alındı *****
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName); // db'deki karşığı olan Categories alındı...
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto); // Bu yapı sayesinde createCategoryDto'daki değerleri mapleyerek Categories tablosuna insert yapabileceğiz.
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x=> x.CategoryID == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x =>true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find<Category>(x => x.CategoryID == id).FirstOrDefaultAsync(); // veriyi önce entity içerisinde buluyoruz.
            return _mapper.Map<GetByIdCategoryDto>(values); // sonra bulduğumuz veriyi mapliyoruz.
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x=>x.CategoryID == updateCategoryDto.CategoryID,values); // ???????????
        }
    }
}
