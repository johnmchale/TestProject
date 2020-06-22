using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;

namespace TestProject.Repository
{
    public class OrderDetailRepository : Repository<OrderDetail>
    {
        public OrderDetailRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }

}
