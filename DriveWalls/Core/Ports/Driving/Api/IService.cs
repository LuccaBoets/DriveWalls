using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ports.Driving.Api
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();
        T GetById(int id);

        T Create(T @object);
        T Update(T modifiedObject);
        void Delete(T @object);
    }
}
