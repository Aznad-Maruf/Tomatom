using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Ecommerce.BLL.Abstruction;
using Ecommerce.BLL.Abstruction.Base;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction;

namespace Ecommerce.BLL
{
    public class UserManager: Manager<User, IUserRepository>, IUserManager
    {
        public UserManager(IUserRepository repository) : base(repository)
        {
        }
    }
}
