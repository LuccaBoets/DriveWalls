using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Driving.Api
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task<T> Create(T @object);
        Task<T> Update(T modifiedObject);
        void Delete(string id);
    }
}
