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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly EcommerceDbContext _db;

        public CategoryRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (EcommerceDbContext)dbContext;
        }
        public override ICollection<Category> GetAll()
        {
            return _db.Categories.Where(c => c.IsDeleted == false).ToList();
        }

        public override ICollection<Category> GetByRequest(Category category)
        {
            var categories = _db.Categories.AsQueryable();
            categories = categories.Where(c => c.IsDeleted == false);
            if (category is null) return categories.ToList();
            categories = categories.Where(c => c.Name.ToLower().Equals(category.Name.ToLower()));

            return categories.ToList();
        }
    }
}
