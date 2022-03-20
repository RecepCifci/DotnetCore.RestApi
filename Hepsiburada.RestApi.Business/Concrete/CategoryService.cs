using Hepsiburada.RestApi.Business.Abstract;
using Hepsiburada.RestApi.DataAccess.Abstract;
using Hepsiburada.RestApi.DataAccess.Concrete;
using Hepsiburada.RestApi.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _service;
        public CategoryService(ICategoryRepository service)
        {
            _service = service;
        }
        public async Task<Category> Get(string id)
        {
            return await _service.Get(id);
        }
        public async Task Post(Category category)
        {
            await _service.Post(category);
        }
        public async Task<bool> Put(string id, Category category)
        {
            return await _service.Put(id, category);
        }
        public async Task<bool> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}
