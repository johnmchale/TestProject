using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Repository
{
    public class ProductRepository : Repository<Product>
    {
        public ProductRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }

}
