using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Repository.Abstruction.Base;

namespace Ecommerce.BLL.Abstruction.Base
{
    public class Manager<T, TU> : IManager<T>where T: class where TU: IRepository<T>
    {
        //private readonly IRepository<T> _repository;
        private readonly TU _repository;

        public Manager(TU repository)
        {
            this._repository = repository;
            
        }
        public bool Add(T entity)
        {
            return _repository.Add(entity);
        }

        public ICollection<T> GetAll()
        {
            return _repository.GetAll();
        }

        public ICollection<T> GetByRequest(T entity)
        {
            return _repository.GetByRequest(entity);
        }

        public T GetById(int id)
        {
            return _repository.GetById(id);
        }

        public bool Remove(T entity)
        {
            return _repository.Remove(entity);
        }

        public bool Update(T entity)
        {
            return _repository.Update(entity);
        }
    }
}
