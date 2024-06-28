using AutoMapper;
using CarRentService.BLL.Services.Contracts;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.DAL.Models;
using CarRentService.DAL.UOF;
using CarRentService.Shared.DTOs.Requests;

namespace CarRentService.BLL.Services
{
    public class RentedCarService : IRentedCarService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public RentedCarService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<RentedCar> AddRentedCarToSystemAsync(RentedCarRequestDTO rentedCarDTO, CancellationToken cancellationToken)
        {
            try
            {
                var car = await _unitOfWork.CarRepository.GetByIdAsync(rentedCarDTO.CarId);
                RentedCar rentedCar = _mapper.Map<RentedCar>(rentedCarDTO);

                var days = (rentedCarDTO.ReturnDate - rentedCarDTO.RentDate).Days;
                rentedCar.RentalCost = car.RentalCost * days;

                rentedCar.IsReturned = false;

                var result = await _unitOfWork.RentedCarRepository.AddAsync(rentedCar);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while adding rentedCar to system, in rentedCar service");
            }
        }
        public async Task<RentedCarDTO> GetCarByIdAsync(int id, CancellationToken cancellationToken)
        {
            var rentedCar = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            var result = _mapper.Map<RentedCarDTO>(rentedCar);
            return result;
        }

        public async Task DeleteRentedCarInSystemAsync(int id, CancellationToken cancellationToken)
        {
            var rentedCar_to_delete = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            if (rentedCar_to_delete == null)
            {
                throw new Exception($"RentedCar with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.RentedCarRepository.DeleteByIdAsync(id);
                await _unitOfWork.CompleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to delete rentedCar from database");
            }
        }

        public async Task<IEnumerable<RentedCarDTO>> GetAllRentedCarsAsync(CancellationToken cancellationToken, string entityHistory = null, int entityId = 0, string orderby = null)
        {
            var all_rentedCars = await _unitOfWork.RentedCarRepository.GetAllAsync(entityHistory, entityId, orderby);
            return _mapper.Map<IEnumerable<RentedCarDTO>>(all_rentedCars);
        }

        public async Task<RentedCarDTO> GetRentedCarByIdAsync(int id, CancellationToken cancellationToken)
        {
            var rented_car = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            return _mapper.Map<RentedCarDTO>(rented_car);
        }

        public async Task<RentedCarDTO> ReturnUpdateRentedCarInSystemAsync(int id, CancellationToken cancellationToken)
        {
            var rentedCar = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            if(rentedCar == null)
            {
                throw new Exception($"RentedCar with {id} cannot be found");
            }
            rentedCar.IsReturned = true;
            if(rentedCar.ReturnDate < DateTime.Today)
            {
                var fine = await _unitOfWork.FineRepository.GetByIdAsync(1);
                rentedCar.RentalCost += fine.Amount;
            }
            await _unitOfWork.RentedCarRepository.UpdateAsync(rentedCar);
            await _unitOfWork.CompleteAsync(cancellationToken);
            var result = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            return _mapper.Map<RentedCarDTO>(result);
        }

        public async Task<RentedCar> UpdateRentedCarInSystemAsync(int id, RentedCarDTO rentedCarDTO, CancellationToken cancellationToken)
        {
            var rentedCar_to_update = await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            if (rentedCar_to_update == null)
            {
                throw new Exception($"RentedCar with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.RentedCarRepository.UpdateAsync(_mapper.Map<RentedCar>(rentedCarDTO));
                await _unitOfWork.CompleteAsync(cancellationToken);
                return await _unitOfWork.RentedCarRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update rentedCar from database");
            }
        }
    }
}
