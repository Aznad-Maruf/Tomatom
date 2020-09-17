using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstruction;
using Ecommerce.BLL.Abstruction.Base;
using Ecommerce.Model.HelpingModels;
using Ecommerce.Repository.Abstruction;

namespace Ecommerce.BLL
{
    public class CartItemManager:Manager<CartItem, ICartItemRepository>, ICartItemManager
    {
        public CartItemManager(ICartItemRepository repository) : base(repository)
        {
        }
    }
}
