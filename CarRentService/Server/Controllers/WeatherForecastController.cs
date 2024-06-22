using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;
using CarRentService.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICarRepository carRepository;
        private CarRentServiceContext context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICarRepository carRepository, CarRentServiceContext context)
        {
            _logger = logger;
            this.carRepository = carRepository;
            this.context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IEnumerable<WeatherForecast> Get()
        {
            var res = carRepository.AddAsync(new Car { Code = "kj31lkj", Brand = "nissan", Cost = 200409, RentalCost = 3000});
            context.SaveChanges();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
