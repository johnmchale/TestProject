using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Contracts;

namespace TestProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected RepositoryContext repositoryContext; 

        public Repository(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public void Create(T obj)
        {
            repositoryContext.Set<T>().Add(obj); 
        }

        public void Delete(object id)
        {
            T t = repositoryContext.Set<T>().Find(id);
            repositoryContext.Remove(t); 
        }

        public virtual IEnumerable<T> GetAll()
        {
            return repositoryContext.Set<T>().ToList();
        }

        public T Get(object id)
        {
            return repositoryContext.Set<T>().Find(id); 
        }

        public void Update(T obj)
        {
            repositoryContext.Entry(obj).State = EntityState.Modified;
            
            //repositoryContext.Set<T>().Update(obj);
        }
    }
}


