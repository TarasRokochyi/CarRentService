using AutoMapper;
using CarRentService.Server.DTOs;
using CarRentService.Server.Models;
using CarRentService.Server.Services.Contracts;
using CarRentService.Server.UOF;

namespace CarRentService.Server.Services
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

        public async Task<RentedCar> AddRentedCarToSystem(RentedCarDTO rentedCarDTO, CancellationToken cancellationToken)
        {
            try
            {
                RentedCar rentedCar = _mapper.Map<RentedCar>(rentedCarDTO);
                var result = await _unitOfWork.RentedCarRepository.AddAsync(rentedCar);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while adding rentedCar to system, in rentedCar service");
            }
        }

        public async Task DeleteRentedCarInSystem(int id, CancellationToken cancellationToken)
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

        public async Task<IEnumerable<RentedCarDTO>> GetAllRentedCars(CancellationToken cancellationToken)
        {
            var all_rentedCars = await _unitOfWork.RentedCarRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<RentedCarDTO>>(all_rentedCars);
        }

        public async Task<RentedCar> UpdateRentedCarInSystem(int id, RentedCarDTO rentedCarDTO, CancellationToken cancellationToken)
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
