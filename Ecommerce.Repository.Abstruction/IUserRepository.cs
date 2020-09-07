using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction.Base;

namespace Ecommerce.Repository.Abstruction
{
    public interface IUserRepository: IRepository<User>
    {
    }
}
