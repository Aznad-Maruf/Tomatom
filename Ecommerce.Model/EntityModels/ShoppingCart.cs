using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.Contracts;
using Ecommerce.Model.HelpingModels;

namespace Ecommerce.Model.EntityModels
{
    public class ShoppingCart:IDeletable
    {
        public int Id { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public bool IsDeleted { get; set; } = false;
        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
