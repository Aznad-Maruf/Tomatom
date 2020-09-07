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
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _manager;
        public ProductController(IProductManager manager)
        {
            _manager = manager;
        }
        // GET: api/Product
        [HttpGet]
        public IActionResult Get()
        {
            var result = _manager.GetAll();
            return Ok(result);

            //var temp = {'a': "d"};
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Id must be positive");
            var result = _manager.GetById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _manager.Add(product);
                if (isSaved)
                {
                    return CreatedAtRoute("Get", new { id = product.Id }, product);
                }

                return BadRequest(ModelState);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            var existingProduct = _manager.GetById(id);
            if (existingProduct == null) return BadRequest();

            existingProduct.CategoryId = product.CategoryId;
            existingProduct.Price = product.Price;
            existingProduct.ImageUrl = product.ImageUrl;
            existingProduct.Name = product.Name;

            bool isUpdated = _manager.Update(existingProduct);
            if (isUpdated) return Ok(existingProduct);
            return BadRequest("Update Failed");
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
