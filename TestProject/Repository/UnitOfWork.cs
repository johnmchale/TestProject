using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Contracts;
using TestProject.Models;

namespace TestProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryContext _repositoryContext;

        private IRepository<Customer> _customerRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<OrderDetail> _orderDetailRepository;
        private IRepository<Product> _productRepository;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext; 
        }

        public IRepository<Customer> customerRepository
        {
            get
            {
                if (_customerRepository == null) _customerRepository = new Repository<Customer>(_repositoryContext);

                return _customerRepository;
            }
        }

        public IRepository<Order> orderRepository
        {
            get
            {
                if (_orderRepository == null) _orderRepository = new Repository<Order>(_repositoryContext);
                    
                return _orderRepository;
             }
        }

        public IRepository<OrderDetail> orderDetailRepository
        {
            get
            {
                if (_orderDetailRepository == null) _orderDetailRepository = new Repository<OrderDetail>(_repositoryContext);
                    
                return _orderDetailRepository;
 
            }
        }

        public IRepository<Product> productRepository
        {
            get
            {
                if (_productRepository == null) _productRepository = new Repository<Product>(_repositoryContext);

                return _productRepository;

            }
        }
        
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
