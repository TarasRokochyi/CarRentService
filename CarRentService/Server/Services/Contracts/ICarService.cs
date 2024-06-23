﻿using CarRentService.Shared.DTOs;
using CarRentService.Server.Models;

namespace CarRentService.Server.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<ShortCarDTO>> GetAllCarsAsync(CancellationToken cancellationToken);
        Task<Car> AddCarToSystemAsync(CarDTO carDTO, CancellationToken cancellationToken); 
        Task<Car> UpdateCarInSystemAsync(int Id, CarDTO carDTO, CancellationToken cancellationToken);
        Task DeleteCarFromSystemAsync(int Id, CancellationToken cancellationToken);
        Task<CarDTO> GetCarByIdAsync(int id, CancellationToken cancellationToken);

    }
}
