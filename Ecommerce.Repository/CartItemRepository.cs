using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database;
using Ecommerce.Model.HelpingModels;
using Ecommerce.Repository.Abstruction;
using Ecommerce.Repository.Abstruction.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class CartItemRepository:Repository<CartItem>, ICartItemRepository
    {
        private readonly EcommerceDbContext _dbContext;
        public CartItemRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = (EcommerceDbContext) dbContext;
        }

        public override ICollection<CartItem> GetByRequest(CartItem entity)
        {
            var cartItems = _dbContext.CartItems.AsQueryable();
            cartItems = cartItems.Include(c=>c.Product).Where(c => c.ShoppingCartId == entity.ShoppingCartId);
            return cartItems.ToList();
        }
    }
}
