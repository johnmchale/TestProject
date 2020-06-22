using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Contracts;

namespace TestProject.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RepositoryContext _repositoryContext;

        private CustomerRepository _customerRepository;
        private OrderRepository _orderRepository;
        private OrderDetailRepository _orderDetailRepository;
        private ProductRepository _productRepository;

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext; 
        }

        public CustomerRepository Customer
        {
            get
            {
                if (_customerRepository == null) _customerRepository = new CustomerRepository(_repositoryContext);

                return _customerRepository;
            }
        }

        public OrderRepository Order
        {
            get
            {
                if (_orderRepository == null) _orderRepository = new OrderRepository(_repositoryContext);
                    
                return _orderRepository;
             }
        }

        public OrderDetailRepository OrderDetail
        {
            get
            {
                if (_orderDetailRepository == null) _orderDetailRepository = new OrderDetailRepository(_repositoryContext);
                    
                return _orderDetailRepository;
 
            }
        }

        public ProductRepository Product
        {
            get
            {
                if (_productRepository == null) _productRepository = new ProductRepository(_repositoryContext);

                return _productRepository;

            }
        }
        
        public void Save()
        {
            _repositoryContext.SaveChanges();
        }
    }
}
