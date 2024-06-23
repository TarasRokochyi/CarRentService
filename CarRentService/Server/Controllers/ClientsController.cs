using CarRentService.Shared.DTOs;
using CarRentService.Server.Repositories.Contracts;
using CarRentService.Server.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CarRentService.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly ILogger<ClientsController> _logger;
        private readonly IClientService _clientService;

        public ClientsController(ILogger<ClientsController> logger, IClientService clientService)
        {
            _logger = logger;
            _clientService = clientService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetAllClients(CancellationToken cancellationToken)
        {
            var result = await _clientService.GetAllClientsAsync(cancellationToken);
            if(result == null)
            {
                _logger.LogInformation($"There is no clients in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Received clients from database");
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetById(int id, CancellationToken cancellationToken)
        {
            var result = await _clientService.GetClientByIdAsync(id, cancellationToken);
            if(result == null)
            {
                _logger.LogInformation($"There is no clients in database");
                return NotFound();
            }
            else
            {
                _logger.LogInformation($"Received clients from database");
                return Ok(result);
            }
        }
    }
}
