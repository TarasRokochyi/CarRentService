using CarRentService.Server.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.Services.Contracts
{
    public interface IRentedCarService
    {
        Task<RentedCar> AddRentedCarToSystem(RentedCarDTO rentedCarDTO, CancellationToken cancellationToken);
        Task<RentedCar> UpdateRentedCarInSystem(int rentId, RentedCarDTO rentedCarDTO, CancellationToken cancellationToken);
        Task DeleteRentedCarInSystem(int rentId,  CancellationToken cancellationToken);
        Task<IEnumerable<RentedCarDTO>> GetAllRentedCars(CancellationToken cancellationToken);
    }
}
