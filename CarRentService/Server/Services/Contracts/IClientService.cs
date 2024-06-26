using CarRentService.Server.Models;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;

namespace CarRentService.Server.Services.Contracts
{
    public interface IClientService
    {
        Task DeleteClientFromSystemAsync(int Id, CancellationToken cancellationToken);
        Task<Models.Client> AddClientToSystemAsync(ClientRequestDTO DTO,  CancellationToken cancellationToken);
        Task<Models.Client> UpdateClientInSystemAsync(int id, ClientDTO clientDTO, CancellationToken cancellationToken);
        Task<IEnumerable<ShortClientDTO>> GetAllClientsAsync(CancellationToken cancellation);
        Task<ClientDTO> GetClientByIdAsync(int id, CancellationToken cancellationToken);
    }
}
