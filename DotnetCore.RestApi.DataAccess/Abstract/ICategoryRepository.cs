using DotnetCore.RestApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.DataAccess.Abstract
{
    public interface ICategoryRepository
    {
        Task<Category> Get(string id);
        Task Post(Category entity);
        Task<bool> Put(string id, Category entity);
        Task<bool> Delete(string id);
    }
}
