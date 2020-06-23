using Microsoft.AspNetCore.Mvc;
using TestProject.Models;

namespace TestProject.Contracts
{
    public interface ICustomerController
    {
        IActionResult CreateCustomer([FromBody] Customer customer);
        IActionResult DeleteCustomer(int id);
        IActionResult Get(int id);
        IActionResult GetCustomers();
        IActionResult UpdateCustomer(int id, [FromBody] Customer customer);
    }
}