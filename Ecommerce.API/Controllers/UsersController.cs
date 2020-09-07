using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.BLL.Abstruction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Model.EntityModels;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserManager _manager;

        public UsersController(IUserManager manager)
        {
            _manager = manager;
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var result = _manager.GetAll();
            return Ok(result);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            if (id < 0) return BadRequest("Id must be positive");
            var result = _manager.GetById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                bool isSaved = _manager.Add(user);
                if (isSaved)
                {
                    return CreatedAtRoute("Get", new {id = user.Id}, user);
                }

                return BadRequest(ModelState);
            }

            return BadRequest(ModelState);
        }

        // PUT: api/Users/5
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
