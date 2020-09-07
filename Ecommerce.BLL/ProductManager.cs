using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstruction;
using Ecommerce.BLL.Abstruction.Base;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;

namespace Ecommerce.BLL
{
    public class ProductManager:Manager<Product, IProductRepository>, IProductManager
    {
        public ProductManager(IProductRepository repository) : base(repository)
        {
        }
    }
}
