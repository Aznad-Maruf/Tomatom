using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.Contracts;

namespace Ecommerce.Model.EntityModels
{
    public class Product:IDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        public string ImageUrl { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void Delete() { IsDeleted = true; }
    }
}
