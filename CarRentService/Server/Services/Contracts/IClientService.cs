using CarRentService.Server.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.Services.Contracts
{
    public interface IClientService
    {
        Task DeleteClientFromSystemAsync(int Id, CancellationToken cancellationToken);
        Task<Models.Client> AddClientToSystemAsync(ClientDTO DTO,  CancellationToken cancellationToken);
        Task<Models.Client> UpdateClientInSystemAsync(int id, ClientDTO clientDTO, CancellationToken cancellationToken);
        Task<IEnumerable<ClientDTO>> GetAllClientsAsync(CancellationToken cancellation);
    }
}
