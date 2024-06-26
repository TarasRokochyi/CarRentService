using CarRentService.Server.Models;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;

namespace CarRentService.Server.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CardCarDTO>> GetAllCarsAsync(CancellationToken cancellationToken);
        Task<Car> AddCarToSystemAsync(CarRequestDTO carDTO, CancellationToken cancellationToken); 
        Task<Car> UpdateCarInSystemAsync(int Id, CarDTO carDTO, CancellationToken cancellationToken);
        Task DeleteCarFromSystemAsync(int Id, CancellationToken cancellationToken);
        Task<CarDTO> GetCarByIdAsync(int id, CancellationToken cancellationToken);

    }
}
