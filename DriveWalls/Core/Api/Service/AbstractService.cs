using Core.Ports.Driving.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Api.Service
{
    public class Service<T> : IService<T>
    {
        private IRepository<T> repository;

        public Service(IRepository<T> repository)
        {
            this.repository = repository;
        }

        public async virtual Task<List<T>> GetAll()
        {
            return await repository.GetAll();
        }

        public async virtual Task<T> GetById(string id)
        {
            return await repository.GetById(id);
        }

        public async virtual Task<T> Create(T @object)
        {
            return await repository.Create(@object);
        }
        public async virtual Task<T> Update(T modifiedObject)
        {
            return await repository.Update(modifiedObject);
        }

        public async virtual void Delete(string id)
        {
            repository.Delete(id);
        }
    }
}
