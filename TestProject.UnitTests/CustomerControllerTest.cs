using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using TestProject.Contracts;
using TestProject.Controllers;
using TestProject.Models;
using TestProject.Repository;
using Xunit;

namespace TestProject.UnitTests
{
    public class CustomerControllerTest
    {

        Mock<ILogger<CustomerController>> _mockLogger;
        Mock<IRepository<Customer>> _mockCustomerRepository;
        Mock<IUnitOfWork> _mockUnitOfWork; 

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

            _mockLogger = new Mock<ILogger<CustomerController>>(); 

            _mockCustomerRepository = new Mock<IRepository<Customer>>();
            _mockCustomerRepository.Setup(m => m.GetAll()).Returns(listCustomer); 

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork.Setup(x => x.customerRepository).Returns(_mockCustomerRepository.Object);

            ICustomerController sut = new CustomerController(_mockUnitOfWork.Object,
                                                             _mockLogger.Object);

            // Act
            var result = sut.GetCustomers();
            var okResult = result as OkObjectResult; 

            // Assert 
            Assert.IsType<OkObjectResult>(okResult);
            Assert.Equal(3, ((System.Collections.Generic.List<TestProject.Models.Customer>)okResult.Value).Count); 
        }
    }
}
