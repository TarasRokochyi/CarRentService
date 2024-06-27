using CarRentService.DAL.Models;
using CarRentService.Shared.DTOs.Responses;

namespace CarRentService.BLL.Services.Contracts
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
