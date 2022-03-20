using AutoMapper;
using Hepsiburada.RestApi.DataAccess.Model;
using Hepsiburada.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.Api
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductModel, Product>();
            CreateMap<CategoryModel, Category>();


            CreateMap<Product, ProductModel>().ForMember(x => x.CategoryId, opt => opt.Ignore());
            CreateMap<Category, CategoryModel>();
        }
    }
}
