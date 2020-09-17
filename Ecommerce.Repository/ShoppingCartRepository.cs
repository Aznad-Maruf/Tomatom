using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Ecommerce.Database;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;
using Ecommerce.Repository.Abstruction.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ShoppingCartRepository:Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public ShoppingCartRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (EcommerceDbContext) dbContext;
        }

        public override ShoppingCart GetById(int id)
        {
            return _dbContext.ShoppingCarts.FirstOrDefault(c => c.Id == id);
        }
    }
}
