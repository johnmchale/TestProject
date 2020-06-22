using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestProject.Contracts;
using TestProject.Models;

namespace TestProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {


        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IUnitOfWork _unitOfWork; 
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IUnitOfWork unitOfWork, ILogger<WeatherForecastController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // http://localhost:5000/weatherforecast 
        [HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        public IActionResult GetCustomers() 
        {
            var rng = new Random();

            _logger.LogInformation($"Hello, I'm in WeatherForecastController, Random ==> {rng}");

            var customers = _unitOfWork.Customer.GetAll();

            return Ok(customers);  

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),();
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }


        [HttpPost]
        //public IEnumerable<WeatherForecast> Get()
        public IActionResult CreateCustomers([FromBody]Customer customer)
        {
            //var rng = new Random();

            //_logger.LogInformation($"Hello, I'm in WeatherForecastController, Random ==> {rng}");

            //var customers = _unitOfWork.Customer.GetAll();
            _unitOfWork.Customer.Create(customer);
            _unitOfWork.Save();

            return Ok(); 

            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),();
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
        }
    }
}
