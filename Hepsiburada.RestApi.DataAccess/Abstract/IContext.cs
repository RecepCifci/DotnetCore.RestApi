using Hepsiburada.RestApi.DataAccess.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.DataAccess.Abstract
{
    public interface IContext
    {
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<Category> Categories { get; }
    }
}
