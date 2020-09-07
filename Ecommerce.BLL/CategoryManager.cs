using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.BLL.Abstruction;
using Ecommerce.BLL.Abstruction.Base;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;

namespace Ecommerce.BLL
{
    public class CategoryManager:Manager<Category, ICategoryRepository>, ICategoryManager
    {
        public CategoryManager(ICategoryRepository repository) : base(repository)
        {
        }
    }
}
