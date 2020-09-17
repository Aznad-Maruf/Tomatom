using Ecommerce.Model.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Repository.Abstruction.Base
{
    public abstract class Repository<T> : IRepository<T> where T: class
    {
        protected readonly DbContext _dbContext;

        private DbSet<T> Table => _dbContext.Set<T>();

        protected Repository(DbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public bool Add(T entity)
        {
            Table.Add(entity);
            return _dbContext.SaveChanges() > 0;
        }

        public virtual ICollection<T> GetAll()
        {
            return Table.ToList();
        }

        public virtual ICollection<T> GetByRequest(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual T GetById(int id)
        {
            return Table.Find(id);
        }

        public bool Remove(T entity)
        {
            if (entity is IDeletable deletable)
            {
                deletable.Delete();
                return Update(entity);
            }

            Table.Remove(entity);

            return false;
        }

        public bool Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges() > 0;
        }
    }
}
