using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL.Abstruction;
using Ecommerce.Model.HelpingModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemManager _manager;
        public CartItemController(ICartItemManager manager)
        {
            _manager = manager;
        }
        // GET: api/CartItem
        [HttpGet]
        public IActionResult Get()
        {
            var result = _manager.GetAll();
            return Ok(result);
        }

        // GET: api/CartItem/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Id must be positive");
            var entity = new CartItem {ShoppingCartId = id};
            var result = _manager.GetByRequest(entity);
            if (result is null) return NotFound();
            return Ok(result);
        }

        // POST: api/CartItem
        [HttpPost]
        public IActionResult Post([FromBody] CartItem entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = 0;
                var existingCartItems = _manager.GetByRequest(entity);
                bool isSaved=false;
                foreach (CartItem item in existingCartItems)
                {
                    if (item.ProductId==entity.ProductId)
                    {
                        if (entity.Quantity == -1) item.Quantity = Math.Max(0, item.Quantity - 1);
                        else item.Quantity++;
                        isSaved = _manager.Update(item);
                        return Ok(item);
                    }
                }

                entity.Quantity = 1;
                isSaved = _manager.Add(entity);

                if (isSaved) return Ok(entity);
                return BadRequest("Some error occured!");
            }

            return BadRequest(ModelState);
        }

        // POST: api/CartItem/5
        [HttpPost("{id}")]
        public IActionResult Post2([FromBody] CartItem entity)
        {
            if (ModelState.IsValid)
            {
                entity.Id = 0;
                var existingCartItems = _manager.GetByRequest(entity);
                bool isSaved = false;
                foreach (CartItem item in existingCartItems)
                {
                    if (item.ProductId == entity.ProductId)
                    {
                        if (entity.Quantity == -1) item.Quantity = Math.Max(0, item.Quantity - 1);
                        else item.Quantity++;
                        isSaved = _manager.Update(item);
                        return Ok(item);
                    }
                }

                entity.Quantity = 1;
                isSaved = _manager.Add(entity);

                if (isSaved) return Ok(entity);
                return BadRequest("Some error occured!");
            }

            return BadRequest(ModelState);
        }

        // PUT: api/CartItem/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CartItem entity)
        {
            entity.Id = id;
            var existingEntity = _manager.GetById(id);
            if (existingEntity == null) return BadRequest();

            existingEntity.ShoppingCartId = entity.ShoppingCartId;
            existingEntity.ProductId = entity.ProductId;
            existingEntity.Quantity = entity.Quantity;


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
