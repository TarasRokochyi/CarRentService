using AutoMapper;
using CarRentService.Server.DTOs;
using CarRentService.Server.Models;
using CarRentService.Server.Services.Contracts;
using CarRentService.Server.UOF;

namespace FineRentService.Server.Services
{
    public class FineService : IFineService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public FineService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Fine> AddFineToSystemAsync(FineDTO fineDTO, CancellationToken cancellationToken)
        {
            try
            {
                Fine fine = _mapper.Map<Fine>(fineDTO);
                var result = await _unitOfWork.FineRepository.AddAsync(fine);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while adding fine to system, in fine service");
            }
        }

        public async Task DeleteFineFromSystem(int id, CancellationToken cancellationToken)
        {
            var fine_to_delete = await _unitOfWork.FineRepository.GetByIdAsync(id);
            if (fine_to_delete == null)
            {
                throw new Exception($"Fine with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.FineRepository.DeleteByIdAsync(id);
                await _unitOfWork.CompleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to delete fine from database");
            }
        }

        public async Task<IEnumerable<FineDTO>> GetAllFinesAsync(CancellationToken cancellationToken)
        {
            var all_fines = await _unitOfWork.FineRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FineDTO>>(all_fines);
        }

        public async Task<Fine> UpdateFineInSystemAsync(int id, FineDTO fineDTO, CancellationToken cancellationToken)
        {
            var fine_to_update = await _unitOfWork.FineRepository.GetByIdAsync(id);
            if (fine_to_update == null)
            {
                throw new Exception($"Fine with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.FineRepository.UpdateAsync(_mapper.Map<Fine>(fineDTO));
                await _unitOfWork.CompleteAsync(cancellationToken);
                return await _unitOfWork.FineRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update fine from database");
            }
        }
    }
}
