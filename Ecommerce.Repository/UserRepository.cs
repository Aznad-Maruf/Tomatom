using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ecommerce.Database;
using Ecommerce.Model.EntityModels;
using Ecommerce.Repository.Abstruction.Base;
using Ecommerce.Repository.Abstruction;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _db;
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            _db = (EcommerceDbContext) dbContext;
        }

        public override ICollection<User> GetAll()
        {
            return _db.Users.Where(c => c.IsDeleted == false).ToList();
        }

        public override ICollection<User> GetByRequest(User user)
        {
            var users = _db.Users.AsQueryable();
            users = users.Where(c => c.IsDeleted == false);
            if (user is null) return users.ToList();
            users = users.Where(c => c.Email.ToLower().Equals(user.Email.ToLower()));
            users = users.Where(c => c.Password == user.Password);

            return users.ToList();
        }
    }
}
