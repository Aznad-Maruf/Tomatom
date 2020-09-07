using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;
using Ecommerce.Repository.Abstruction.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductRepository:Repository<Product>, IProductRepository

    {
        private readonly EcommerceDbContext _db;
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (EcommerceDbContext) dbContext;
        }
        public override ICollection<Product> GetAll()
        {
            return _db.Products.Include(c=>c.Category).Where(c => c.IsDeleted == false).ToList();
        }

        public override Product GetById(int id)
        {
            return _db.Products.Include(c => c.Category).FirstOrDefault(c=>c.Id==id);
        }

        public override ICollection<Product> GetByRequest(Product product)
        {
            var products = _db.Products.AsQueryable();
            products = products.Where(c => c.IsDeleted == false);
            if (product is null) return products.ToList();
            products = products.Where(c => c.Name.ToLower().Equals(product.Name.ToLower()));
            products = products.Where(c => c.CategoryId==product.CategoryId);
            products = products.Where(c => c.Price.ToString().Equals(product.Price.ToString().ToLower()));
            products = products.Where(c => c.ImageUrl.ToLower().Equals(product.ImageUrl.ToLower()));

            return products.ToList();
        }
    }
}
