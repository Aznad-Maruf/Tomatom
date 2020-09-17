using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using Ecommerce.Model.EntityModels;

namespace Ecommerce.Model.HelpingModels
{
    public class CartItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
