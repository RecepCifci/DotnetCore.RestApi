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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _service;
        private readonly RedisCache<Product> _redisCache;
        public ProductService(IProductRepository service, RedisCache<Product> redisCache)
        {
            _service = service;
            _redisCache = redisCache;
        }
        public async Task<Product> Get(string id)
        {
            var productFromRedis = await _redisCache.GetData(id);

            if (productFromRedis is not null)
                return JsonConvert.DeserializeObject<Product>(productFromRedis);

            var product = await _service.Get(id);

            if (product is null) throw new Exception("Not Found");

            await _redisCache.SetData(product, product.Id);

            return product;
        }
        public async Task Post(Product Product)
        {
            await _service.Post(Product);
        }
        public async Task<bool> Put(string id, Product Product)
        {
            return await _service.Put(id, Product);
        }
        public async Task<bool> Delete(string id)
        {
            return await _service.Delete(id);
        }
    }
}