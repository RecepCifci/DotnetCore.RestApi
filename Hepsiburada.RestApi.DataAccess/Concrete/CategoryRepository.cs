using Hepsiburada.RestApi.DataAccess.Abstract;
using Hepsiburada.RestApi.DataAccess.Model;
using MongoDB.Driver;
using System.Threading.Tasks;


namespace Hepsiburada.RestApi.DataAccess.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IContext _context;
        public CategoryRepository(IContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Category> filter = Builders<Category>.Filter.Eq(p => p.Id, id);

            DeleteResult deleteResult = await _context
                                               .Categories
                                                .DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged
                && deleteResult.DeletedCount > 0;
        }

        public async Task<Category> Get(string id)
        {
            return await _context
                           .Categories
                           .Find(p => p.Id == id)
                           .FirstOrDefaultAsync();
        }

        public async Task Post(Category entity)
        {
            await _context.Categories.InsertOneAsync(entity);
        }

        public async Task<bool> Put(string id, Category entity)
        {
            var updateResult = await _context.Categories.ReplaceOneAsync(u => u.Id == id, entity);
            return updateResult.IsAcknowledged
                  && updateResult.ModifiedCount > 0;
        }
    }
}
