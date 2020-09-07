using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Repository.Abstruction.Base
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
        ICollection<T> GetByRequest(T entity);
    }
}
