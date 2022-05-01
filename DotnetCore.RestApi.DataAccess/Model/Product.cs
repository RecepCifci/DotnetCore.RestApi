using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace DotnetCore.RestApi.DataAccess.Model
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("description")]
        public string Description { get; set; }
        [BsonElement("categoryId")]
        public string CategoryId { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
        [BsonElement("currency")]
        public string Currency { get; set; }
    }
}
