using Hepsiburada.RestApi.Api.FluentValidation;
using Hepsiburada.RestApi.Business.Abstract;
using Hepsiburada.RestApi.DataAccess.Abstract;
using Hepsiburada.RestApi.DataAccess.Concrete;
using Hepsiburada.RestApi.DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hepsiburada.RestApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        CategoryValidator validator = new CategoryValidator();
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Get(string id)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            var category = await _service.Get(id);

            if (category is null)
                return NotFound(Messages.CategoryNotFound(id));

            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Product), (int)HttpStatusCode.Created)]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            var validation = validator.Validate(category);

            if (!validation.IsValid)
                return BadRequest(string.Join(",", validation.Errors));

            await _service.Post(category);

            return Ok(category);
        }


        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Put([FromQuery] string id, [FromBody] Category category)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            var validation = validator.Validate(category);

            if (!validation.IsValid)
                return BadRequest(string.Join(",", validation.Errors));

            bool response = await _service.Put(id, category);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Delete([FromQuery] string id)
        {
            if (String.IsNullOrEmpty(id) || !ObjectId.TryParse(id, out _))
                return BadRequest(Messages.IdFormatError);

            bool response = await _service.Delete(id);

            return Ok(response);
        }
    }
}
