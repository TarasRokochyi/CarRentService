using CarRentService.Server.Models;
using CarRentService.Shared.DTOs.Responses;

namespace CarRentService.Server.Services.Contracts
{
    public interface IRentedCarService
    {
        Task<RentedCar> AddRentedCarToSystemAsync(RentedCarDTO rentedCarDTO, CancellationToken cancellationToken);
        Task<RentedCar> UpdateRentedCarInSystemAsync(int Id, RentedCarDTO rentedCarDTO, CancellationToken cancellationToken);
        Task DeleteRentedCarInSystemAsync(int Id,  CancellationToken cancellationToken);
        Task<IEnumerable<ShortRentedCarDTO>> GetAllRentedCarsAsync(CancellationToken cancellationToken);
        Task<RentedCarDTO> GetRentedCarByIdAsync(int id, CancellationToken cancellationToken);
    }
}
