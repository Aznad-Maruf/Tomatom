using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.Contracts;

namespace Ecommerce.Model.EntityModels
{
    public class Category:IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        // public List<Product> Products { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void Delete() { IsDeleted = true; }
    }
}
