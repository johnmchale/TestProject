using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Contracts;
using TestProject.Models;

namespace TestProject.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {

        public CustomerRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }
    }
}
