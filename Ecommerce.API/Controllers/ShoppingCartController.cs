using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL.Abstruction;
using Ecommerce.Model.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartManager _manager;
        public ShoppingCartController(IShoppingCartManager shoppingCartManager)
        {
            _manager = shoppingCartManager;
        }
        // GET: api/ShoppingCart
        [HttpGet]
        public IActionResult Get()
        {
            var result = _manager.GetAll();
            return Ok(result);
        }

        // GET: api/ShoppingCart/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Id must be positive");
            var result = _manager.GetById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        // POST: api/ShoppingCart
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCart entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = 0;
                bool isSaved = _manager.Add(entity);
                if (isSaved)
                {
                    
                    return CreatedAtRoute("Get", new { id = entity.Id }, entity);
                }

                return BadRequest(ModelState);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/ShoppingCart/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ShoppingCart entity)
        {
            entity.Id = id;
            var existingEntity = _manager.GetById(id);
            if (existingEntity == null) return BadRequest();

            existingEntity.CartItems = entity.CartItems;
            

            bool isUpdated = _manager.Update(existingEntity);
            if (isUpdated) return Ok(existingEntity);
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
