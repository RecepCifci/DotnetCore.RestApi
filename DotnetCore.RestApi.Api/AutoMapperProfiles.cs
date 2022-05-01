using AutoMapper;
using DotnetCore.RestApi.DataAccess.Model;
using DotnetCore.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Api
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
