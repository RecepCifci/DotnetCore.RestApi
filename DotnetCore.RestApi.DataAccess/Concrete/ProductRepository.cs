using DotnetCore.RestApi.DataAccess.Abstract;
using DotnetCore.RestApi.DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotnetCore.RestApi.DataAccess.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly IContext _context;
        public ProductRepository(IContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                                .Products
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Product> Get(string id)
        {
            return await _context
                           .Products
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task Post(Product entity)
        {
            await _context.Products.InsertOneAsync(entity);
        }

        public async Task<bool> Put(string id, Product entity)
        {
            var updateResult = await _context.Products.ReplaceOneAsync(u => u.Id == id, entity);
            return updateResult.IsAcknowledged
                  && updateResult.ModifiedCount > 0;
        }
    }
}
