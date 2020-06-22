using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Repository
{
    public class OrderRepository : Repository<Order>
    {
        public OrderRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }

}
