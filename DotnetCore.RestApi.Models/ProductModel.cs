using System;

namespace DotnetCore.RestApi.Models
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CategoryModel CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
