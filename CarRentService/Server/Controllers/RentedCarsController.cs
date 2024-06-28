using CarRentService.BLL.Services.Contracts;
using CarRentService.Shared.DTOs.Requests;
using CarRentService.Shared.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace CarRentService.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class RentedCarsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IRentedCarService _rentedCarService;

        public RentedCarsController(ILogger<ClientsController> logger, IRentedCarService rentedCarService)
        {
            _logger = logger;
            _rentedCarService = rentedCarService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RentedCarDTO>>> GetAllRentedCars(CancellationToken cancellationToken, [FromQuery]string? entityHistory = "", [FromQuery]int entityId = 0, [FromQuery]string? orderby = "")
        {
            var result = await _rentedCarService.GetAllRentedCarsAsync( cancellationToken, entityHistory, entityId, orderby);
            if(result == null)
            {
                _logger.LogInformation($"There is no rented cars in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Received rented cars from database");
                return Ok(result);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RentedCarDTO>> AddCar(RentedCarRequestDTO rentedCar, CancellationToken cancellationToken)
        {
            var created_rentedcar = await _rentedCarService.AddRentedCarToSystemAsync(rentedCar, cancellationToken);
            this._logger.LogInformation($"added rented car to system with carid: {rentedCar.CarId} and client id {rentedCar.ClientId}");
            return Ok(created_rentedcar);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RentedCarDTO>> GetRentedCarById(int id, CancellationToken cancellationToken)
        {
            var rentedCar = await _rentedCarService.GetRentedCarByIdAsync(id, cancellationToken);
            this._logger.LogInformation($"get car with id: {id}");
            return Ok(rentedCar);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RentedCarDTO>> ReturnACar(int id, CancellationToken cancellationToken)
        {
            var updated_rentedCar = await _rentedCarService.ReturnUpdateRentedCarInSystemAsync(id, cancellationToken);
            return Ok(updated_rentedCar);
        }
    }
}
