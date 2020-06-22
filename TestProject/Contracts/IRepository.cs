using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.Contracts
{
    public interface IRepository<T> where T: class
    {
        void Create(T obj);
        void Delete(object id);
        IEnumerable<T> GetAll();
        T Get(object id);
        void Update(T obj);
        // n.b. Save not required since in UnitOfWork
    }
}

