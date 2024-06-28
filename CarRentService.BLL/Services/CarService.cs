using AutoMapper;
using CarRentService.BLL.Services.Contracts;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;
using CarRentService.BLL.ExternalAPIResponses;
using CarRentService.DAL.Models;
using CarRentService.DAL.UOF;
using System.Net.Http.Json;

namespace CarRentService.BLL.Services
{
    public class CarService : ICarService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;
        private HttpClient Http;

        public CarService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            Http = new HttpClient();
        }


        public async Task<Car> AddCarToSystemAsync(CarRequestDTO carDTO, CancellationToken cancellationToken)
        {
            try
            {
                var carResponse = await Http.GetFromJsonAsync<CarResponse>($"https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvalues/{carDTO.VIN}?format=json");
                //car.Model = carResponse.Results[0].Model;
                var car = _mapper.Map<Car>(carResponse.Results[0]);
                car.Cost = carDTO.Cost;
                car.RentalCost = carDTO.RentalCost;
                car.IsInUse = false;
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

        public async Task<IEnumerable<CardCarDTO>> GetAllCarsAsync(CancellationToken cancellationToken)
        {
            var all_cars = await _unitOfWork.CarRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CardCarDTO>>(all_cars);
        }

        public async Task<CarDTO> GetCarByIdAsync(int id, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.CarRepository.GetByIdAsync(id);
            CarDTO result;
            try { 
                var carResponse = await Http.GetFromJsonAsync<CarResponse>($"https://vpic.nhtsa.dot.gov/api/vehicles/decodevinvalues/{car.VIN}?format=json");
                result = _mapper.Map<CarDTO>(carResponse.Results[0]);
                result.Id = car.Id;
                result.Cost = car.Cost;
                result.RentalCost = car.RentalCost;
                result.IsInUse = car.IsInUse;
            }
            catch(Exception ex)
            {
                result = _mapper.Map<CarDTO>(car);
            }
            return result;
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
