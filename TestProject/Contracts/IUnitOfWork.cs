using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Models;
using TestProject.Repository;

namespace TestProject.Contracts
{
    public interface IUnitOfWork
    {
        //CustomerRepository Customer { get; }
        //OrderRepository Order { get; }
        //OrderDetailRepository OrderDetail { get; }
        //ProductRepository Product { get; }
        //void Save(); 


        IRepository<Customer> customerRepository{ get; }
        IRepository<Order> orderRepository { get; }
        IRepository<OrderDetail> orderDetailRepository { get; }
        IRepository<Product> productRepository{ get; }
        void Save(); 

    }
}
