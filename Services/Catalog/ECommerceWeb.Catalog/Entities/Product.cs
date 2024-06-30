using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ECommerceWeb.Catalog.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }   
        public string ProductName { get; set; }   
        public decimal ProductPrice { get; set; }   
        public string ProductImageUrl { get; set; }   
        public string ProductDesciption { get; set; }
        public string CategoryId { get; set; }
        [BsonIgnore] // Veritabanına kaydedilmeyecek ama program içerisinde kullanılacak alanı temsil eder. 
        public Category Category { get; set; }
    }
}
