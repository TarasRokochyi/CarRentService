using CarRentService.Server.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.Services.Contracts
{
    public interface IFineService
    {
        Task<Fine> AddFineToSystemAsync(FineDTO fineDTO, CancellationToken cancellationToken);
        Task<Fine> UpdateFineInSystemAsync(int id, FineDTO fineDTO, CancellationToken cancellationToken);
        Task DeleteFineFromSystem(int id, CancellationToken cancellationToken);
        Task<IEnumerable<FineDTO>> GetAllFinesAsync(CancellationToken cancellationToken);
    }
}
