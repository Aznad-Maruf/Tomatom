using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.Contracts;

namespace Ecommerce.Model.EntityModels
{
    public class User:IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        public void Delete() { IsDeleted = true; }
    }
}
