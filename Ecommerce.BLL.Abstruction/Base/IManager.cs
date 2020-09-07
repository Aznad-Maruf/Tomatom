using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ecommerce.BLL.Abstruction.Base
{
    public interface IManager<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(T entity);
        T GetById(int id);
        ICollection<T> GetAll();
        ICollection<T> GetByRequest(T entity);
    }
}
