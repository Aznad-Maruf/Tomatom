using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.API.JWT;
using Ecommerce.BLL;
using Ecommerce.BLL.Abstruction;
using Ecommerce.Model.EntityModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public LoginController( IUserManager userManager )
        {
            _userManager = userManager;
        }
        // GET: api/Login
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {tast="test"});
        }

        // GET: api/Login/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            var result = _userManager.GetByRequest(user).ToList();

            if (result.Count == 0) return Unauthorized();

            var token = Token.Generate(result[0]);

            return Ok(new {token=token});
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
