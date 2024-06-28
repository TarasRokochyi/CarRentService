using CarRentService.DAL.Models;
using CarRentService.Shared.DTOs.Requests;
using CarRentService.Shared.DTOs.Responses;

namespace CarRentService.BLL.Services.Contracts
{
    public interface IRentedCarService
    {
        Task<RentedCar> AddRentedCarToSystemAsync(RentedCarRequestDTO rentedCarDTO, CancellationToken cancellationToken);
        Task<RentedCar> UpdateRentedCarInSystemAsync(int Id, RentedCarDTO rentedCarDTO, CancellationToken cancellationToken);
        Task DeleteRentedCarInSystemAsync(int Id,  CancellationToken cancellationToken);
        Task<IEnumerable<RentedCarDTO>> GetAllRentedCarsAsync(CancellationToken cancellationToken, string entityHistory = null, int entityId = 0, string orderby = null);
        Task<RentedCarDTO> GetRentedCarByIdAsync(int id, CancellationToken cancellationToken);
    }
}
