using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstruction;
using Ecommerce.Model.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _manager;
        public CategoryController(ICategoryManager manager)
        {
            _manager = manager;
        }
        // GET: api/Category
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _manager.GetAll();
            return Ok(categories);
        }

        // GET: api/Category/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Id must be positive");
            var result = _manager.GetById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        // POST: api/Category
        [HttpPost]
        public IActionResult Post([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _manager.Add(category);
                if (isSaved)
                {
                    return CreatedAtRoute("Get", new { id = category.Id }, category);
                }

                return BadRequest(ModelState);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _manager.GetById(id);
            if (entity is null) return NotFound();
            bool isDeleted = _manager.Remove(entity);
            return Ok(entity);
        }
    }
}
