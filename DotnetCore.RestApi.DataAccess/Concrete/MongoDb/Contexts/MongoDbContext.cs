using DotnetCore.RestApi.DataAccess.Abstract;
using DotnetCore.RestApi.DataAccess.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DotnetCore.RestApi.DataAccess.Concrete.MongoDb.Contexts
{
    public class MongoDbContext : IContext
    {
        private readonly MongoClient _client;
        private readonly IMongoDatabase _database;

        public MongoDbContext(IOptions<DbSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            _database = _client.GetDatabase(settings.DatabaseName);

            Products = _database.GetCollection<Product>(settings.ProductCollectionName);
            Categories = _database.GetCollection<Category>(settings.CategoryCollectionName);
        }

        public IMongoClient Client => _client;

        public IMongoDatabase Database => _database;

        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }
}
