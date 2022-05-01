using AutoMapper;
using DotnetCore.RestApi.Api.FluentValidation;
using DotnetCore.RestApi.Business.Abstract;
using DotnetCore.RestApi.DataAccess.Model;
using DotnetCore.RestApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DotnetCore.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        ProductValidator validator = new ProductValidator();
        public ProductController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Product>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Get(string id)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            var product = await _productService.Get(id);
            if (product is null)
                return NotFound(Messages.ProductNotFound(id));

            var category = await _categoryService.Get(product.CategoryId);
            if (category is null)
                return NotFound(Messages.CategoryNotFound(id));

            var mappedCategory = _mapper.Map<CategoryModel>(category);

            var productResponse = _mapper.Map<ProductModel>(product);
            productResponse.CategoryId = mappedCategory;

            return Ok(productResponse);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            var validation = validator.Validate(product);

            if (!validation.IsValid)
                return BadRequest(string.Join(",", validation.Errors));

            await _productService.Post(product);

            return Ok(product);
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Put([FromQuery] string id, [FromBody] Product product)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            var validation = validator.Validate(product);

            if (!validation.IsValid)
                return BadRequest(string.Join(",", validation.Errors));

            bool response = await _productService.Put(id, product);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Product>> Delete([FromQuery] string id)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            bool response = await _productService.Delete(id);

            return Ok(response);
        }
    }
}