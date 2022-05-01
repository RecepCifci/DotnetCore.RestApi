using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.DataAccess.Concrete
{
    public class RedisCache<T> where T : class, new()
    {
        private readonly IDatabase _redisCache;
        public RedisCache()
        {
            _redisCache = RedisConnectorHelper.Connection.GetDatabase();
        }
        public async Task<string> GetData(string id)
        {
            return await _redisCache.StringGetAsync(id);
        }
        public async Task<string> SetData(T entity, string id)
        {
            await _redisCache.StringSetAsync(id, JsonConvert.SerializeObject(entity), new TimeSpan(0, 5, 0));
            return await GetData(id);
        }
    }
}