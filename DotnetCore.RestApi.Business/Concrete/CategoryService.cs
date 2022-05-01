using DotnetCore.RestApi.Business.Abstract;
using DotnetCore.RestApi.DataAccess.Abstract;
using DotnetCore.RestApi.DataAccess.Concrete;
using DotnetCore.RestApi.DataAccess.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<Category> Get(string id)
        {
            return await _repository.Get(id);
        }
        public async Task Post(Category category)
        {
            await _repository.Post(category);
        }
        public async Task<bool> Put(string id, Category category)
        {
            return await _repository.Put(id, category);
        }
        public async Task<bool> Delete(string id)
        {
            return await _repository.Delete(id);
        }
    }
}
