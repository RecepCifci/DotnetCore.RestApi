using DotnetCore.RestApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Business.Abstract
{
    public interface IProductService
    {
        Task<Product> Get(string id);
        Task Post(Product entity);
        Task<bool> Put(string id, Product entity);
        Task<bool> Delete(string id);
    }
}
