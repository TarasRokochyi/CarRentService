using CarRentService.BLL.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;

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
        public async Task<ActionResult<IEnumerable<ClientDTO>>> GetClientById(int id, CancellationToken cancellationToken)
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddClient(ClientRequestDTO client, CancellationToken cancellationToken)
        {
            var created_client = await _clientService.AddClientToSystemAsync(client, cancellationToken);
            this._logger.LogInformation($"added client to system {client.FirstName} {client.LastName}");
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteClientByIdAsync(int id, CancellationToken cancellationToken)
        {
            await _clientService.DeleteClientFromSystemAsync(id, cancellationToken);
            _logger.LogInformation($"deleted client with id {id}");
            return Ok();
        }

    }
}
