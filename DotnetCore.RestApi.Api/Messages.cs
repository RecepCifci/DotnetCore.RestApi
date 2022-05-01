using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Api
{
    public static class Messages
    {
        public static string IdFormatError => "Id is not valid 24 digit hex string";
        public static string ProductNotFound(string id) => $"Product not found with id: {id}";
        public static string CategoryNotFound(string id) => $"Category not found with id: {id}";
        public static string EmptyProduct => "Product is empty";
        public static string EmptyCategory => "Category is empty";
        public static string CategoryNameNull => "Category name is null";
        public static string CategoryNameEmpty => "Category name is empty";
        public static string ProductNameNull => "Product name is null";
        public static string ProductNameEmpty => "Product name is empty";
        public static string ProductPriceIsInvalid => "Product Price should be greater than zero";
        public static string ProductCurrencyNull => "Product currency is null";
        public static string ProductCurrencyEmpty => "Product currency is empty";
    }
}
