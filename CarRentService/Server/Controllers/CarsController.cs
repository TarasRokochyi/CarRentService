using CarRentService.Server.Services.Contracts;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CarRentService.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CarsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly ICarService _carService;

        public CarsController(ILogger<ClientsController> logger, ICarService carService)
        {
            _logger = logger;
            _carService = carService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CardCarDTO>>> GetAllCars(CancellationToken cancellationToken)
        {
            var result = await _carService.GetAllCarsAsync(cancellationToken);
            if(result == null)
            {
                _logger.LogInformation($"There is no cars in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Received cars from database");
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CarDTO>> GetCarById(int id, CancellationToken cancellationToken)
        {
            var result = await _carService.GetCarByIdAsync(id, cancellationToken);
            if(result == null)
            {
                _logger.LogInformation($"There is no cars in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Received car from database");
                return Ok(result);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CarDTO>> AddCar(CarRequestDTO car, CancellationToken cancellationToken)
        {
            var created_client = await _carService.AddCarToSystemAsync(car, cancellationToken);
            this._logger.LogInformation($"added car to system {car.VINCode}");
            return Ok();
        }
    }
}
