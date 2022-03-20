using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Hepsiburada.RestApi.DataAccess.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [Required]
        public string Id { get; set; }
        [Required]
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [Required]
        [BsonElement("categoryId")]
        public string CategoryId { get; set; }
        [Required]
        [BsonElement("price")]
        public decimal Price { get; set; }
        [Required]
        [BsonElement("currency")]
        public string Currency { get; set; }
    }
}
