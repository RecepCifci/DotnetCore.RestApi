using DotnetCore.RestApi.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Business.Abstract
{
    public interface ICategoryService
    {
        Task<Category> Get(string id);
        Task Post(Category category);
        Task<bool> Put(string id, Category category);
        Task<bool> Delete(string id);
    }
}
