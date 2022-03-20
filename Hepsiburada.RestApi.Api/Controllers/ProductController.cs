using AutoMapper;
using Hepsiburada.RestApi.Business.Abstract;
using Hepsiburada.RestApi.DataAccess.Model;
using Hepsiburada.RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Get(string id)
        {
            var product = await _productService.Get(id);
            var category = await _categoryService.Get(product.CategoryId);

            var mappedCategory = _mapper.Map<CategoryModel>(category);

            var productResponse = _mapper.Map<ProductModel>(product);
            productResponse.CategoryId = mappedCategory;

            return Ok(productResponse);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            await _productService.Post(product);

            return Ok(product);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Put([FromQuery] string id, [FromBody] Product product)
        {
            bool response = await _productService.Put(id, product);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Delete([FromQuery] string id)
        {
            bool response = await _productService.Delete(id);

            return Ok(response);
        }
    }
}