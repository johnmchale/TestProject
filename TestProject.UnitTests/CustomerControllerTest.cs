using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using TestProject.Contracts;
using TestProject.Controllers;
using TestProject.Models;
using TestProject.Repository;
using Xunit;

namespace TestProject.UnitTests
{
    public class CustomerControllerTest
    {

        Mock<IUnitOfWork> _mockUnitOfWork;
        Mock<ILogger<CustomerController>> _mockLogger;
        
        Mock<CustomerRepository> _mockCustomerRepository;

        CustomerController customerController;
        
        List<Customer> listCustomer = new List<Customer>
        {
                new Customer { CustomerId = 1, Name = "John", AddressLine1 = "1 High St", AddressLine2 = "Burton", AddressLine3 = "UK" },
                new Customer { CustomerId = 2, Name = "Michael", AddressLine1 = "2 High St", AddressLine2 = "Burton", AddressLine3 = "UK" },
                new Customer { CustomerId = 3, Name = "Steven", AddressLine1 = "3 High St", AddressLine2 = "Burton", AddressLine3 = "UK" }
        };




        [Fact]
        public void Get_WhenCalled_ReturnsCustomers()
        {
            // Arrange
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockLogger = new Mock<ILogger<CustomerController>>();
            
            customerController = new CustomerController(_mockUnitOfWork.Object, 
                                                        _mockLogger.Object);

            _mockCustomerRepository = new Mock<CustomerRepository>(); 

            _mockUnitOfWork.Setup(x => x.Customer.GetAll()).Returns(listCustomer);

            // Act
            List<Customer> results = customerController.GetCustomers() as List<Customer>;

            // Assert 
            Assert.NotNull(results);

        }
    }
}
