using CarRentService.Shared.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.Services.Contracts
{
    public interface IFineService
    {
        Task<Fine> AddFineToSystemAsync(FineDTO fineDTO, CancellationToken cancellationToken);
        Task<Fine> UpdateFineInSystemAsync(int id, FineDTO fineDTO, CancellationToken cancellationToken);
        Task DeleteFineFromSystemAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<FineDTO>> GetAllFinesAsync(CancellationToken cancellationToken);
        Task<FineDTO> GetFineByIdAsync(int id, CancellationToken cancellationToken);
    }
}
