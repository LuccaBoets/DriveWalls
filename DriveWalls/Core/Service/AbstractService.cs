using Core.Ports.Driving.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class Service<T>
    {
        private IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public virtual Task<List<T>> GetAll()
        {
            return repository.GetAll();
        }

        public virtual T GetById(int id)
        {
            return repository.GetById(id);
        }

        public virtual T Create(T @object)
        {
            return repository.Create(@object);
        }
        public virtual T Update(T modifiedObject)
        {
            return repository.Update(modifiedObject);
        }

        public virtual void Delete(T @object)
        {
            repository.Delete(@object);
        }
    }
}
