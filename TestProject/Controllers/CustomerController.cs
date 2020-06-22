using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestProject.Contracts;
using TestProject.Models;

namespace TestProject.Controllers
{
    [Route("[controller]")]
    [ApiController]
    // https://localhost:5001/customer
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IUnitOfWork unitOfWork, ILogger<CustomerController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        
        [HttpGet]
        public IActionResult GetCustomers()
        {
            try
            {
                var customers = _unitOfWork.Customer.GetAll();
                return Ok(customers); 
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error getting Customers data");
                return StatusCode(500, "Internal Server Error"); 
            }
        }

        // https://localhost:5001/customer/1
        [HttpGet("{id}", Name = "CustomerById")]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _unitOfWork.Customer.Get(id);
                if (customer == null)
                { 
                    return NotFound(); 
                }

                return Ok(customer); 
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error getting Customer {id}");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // https://localhost:5001/customer
        /* n.b. example post data; no need for customerId since it's an Identity column 
         {
        "name": "Max",
        "addressLine1": "6 High St",
        "addressLine2": "Burton",
        "addressLine3": "UK",
        "orders": null
        }
        */
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null)
                {
                    _logger.LogInformation($"Error creating Customer");
                    return BadRequest("customer object is null");
                }

                _unitOfWork.Customer.Create(customer);
                _unitOfWork.Save(); 

                return CreatedAtRoute("CustomerById", new { id =  customer.CustomerId }, customer); 
            }
            catch (Exception)
            {
                _logger.LogInformation($"Error creating Customer");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // https://localhost:5001/customer/1
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {

            // this can either use id (i.e. customerId) from URL or from request body 
            // I decied to use it from URL 
            try
            {
                if (customer == null)
                {
                    _logger.LogInformation($"Error creating Customer");
                    return BadRequest("customer object is null");
                }

                // this didn't work - clash of transactions for same ID 
                //var cus = _unitOfWork.Customer.Get(id);
                //if (cus == null)
                //{
                //    _logger.LogInformation($"Customer {id} does not exist");
                //    return BadRequest("customer does not exist");
                //}

                customer.CustomerId = id; 
                _unitOfWork.Customer.Update(customer);
                _unitOfWork.Save();

                return NoContent(); 

            }
            catch (Exception)
            {
                _logger.LogInformation($"Error updating Customer");
                return StatusCode(500, "Internal Server Error");
            }
        }

        // https://localhost:5001/customer/1
        [HttpDelete("{id}")]
        public IActionResult DeleteCustomer(int id)
        {

            // this can either use id (i.e. customerId) from URL or from request body 
            // I decied to use it from URL 
            try
            {
                _unitOfWork.Customer.Delete(id);
                _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception)
            {
                _logger.LogInformation($"Error updating Customer");
                return StatusCode(500, "Internal Server Error");
            }
        }

    }
}
