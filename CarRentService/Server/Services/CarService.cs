﻿using AutoMapper;
using CarRentService.Server.DTOs;
using CarRentService.Server.Models;
using CarRentService.Server.Services.Contracts;
using CarRentService.Server.UOF;

namespace CarRentService.Server.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }


        public async Task<Car> AddCarToSystemAsync(CarDTO carDTO, CancellationToken cancellationToken)
        {
            try
            {
                Car car = _mapper.Map<Car>(carDTO);
                var result = await _unitOfWork.CarRepository.AddAsync(car);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while adding car to system, in car service");
            }
        }

        public async Task DeleteCarFromSystemAsync(int id, CancellationToken cancellationToken)
        {
            var car_to_delete = await _unitOfWork.CarRepository.GetByIdAsync(id);
            if (car_to_delete == null)
            {
                throw new Exception($"Car with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.CarRepository.DeleteByIdAsync(id);
                await _unitOfWork.CompleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to delete car from database");
            }
        }

        public async Task<IEnumerable<CarDTO>> GetAllCarsAsync(CancellationToken cancellationToken)
        {
            var all_cars = await _unitOfWork.CarRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CarDTO>>(all_cars);
        }

        public async Task<Car> UpdateCarInSystemAsync(int id, CarDTO carDTO, CancellationToken cancellationToken)
        {
            var car_to_update = await _unitOfWork.CarRepository.GetByIdAsync(id);
            if (car_to_update == null)
            {
                throw new Exception($"Car with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.CarRepository.UpdateAsync(_mapper.Map<Car>(carDTO));
                await _unitOfWork.CompleteAsync(cancellationToken);
                return await _unitOfWork.CarRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update car from database");
            }
        }
    }
}