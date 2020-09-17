using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstruction;
using Ecommerce.BLL.Abstruction.Base;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;

namespace Ecommerce.BLL
{
    public class ShoppingCartManager:Manager<ShoppingCart, IShoppingCartRepository>, IShoppingCartManager
    {
        public ShoppingCartManager(IShoppingCartRepository repository) : base(repository)
        {
        }
    }
}
