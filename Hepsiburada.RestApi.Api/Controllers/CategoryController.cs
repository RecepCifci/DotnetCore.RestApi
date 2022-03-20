using Hepsiburada.RestApi.Business.Abstract;
using Hepsiburada.RestApi.DataAccess.Abstract;
using Hepsiburada.RestApi.DataAccess.Concrete;
using Hepsiburada.RestApi.DataAccess.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(IEnumerable<Category>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _service.Get(id);
            return Ok(category);
        }


        [HttpPost]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            await _service.Post(category);

            return Ok(category);
        }


        [HttpPut]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Put([FromQuery] string id, [FromBody] Category category)
        {
            bool response = await _service.Put(id, category);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Category), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Category>> Delete([FromQuery] string id)
        {
            bool response = await _service.Delete(id);

            return Ok(response);
        }
    }
}
