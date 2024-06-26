using AutoMapper;
using CarRentService.Server.Services.Contracts;
using CarRentService.Server.UOF;
using CarRentService.Shared.DTOs.Responses;
using CarRentService.Shared.DTOs.Requests;

namespace CarRentService.Server.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork;

        public ClientService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Models.Client> AddClientToSystemAsync(ClientRequestDTO clientDTO, CancellationToken cancellationToken)
        {
            try
            {
                Models.Client client = _mapper.Map<Models.Client>(clientDTO);
                var result = await _unitOfWork.ClientRepository.AddAsync(client);
                await _unitOfWork.CompleteAsync(cancellationToken);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("error while adding client to system, in client service");
            }
        }

        public async Task DeleteClientFromSystemAsync(int id, CancellationToken cancellationToken)
        {
            var client_to_delete = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (client_to_delete == null)
            {
                throw new Exception($"Client with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.ClientRepository.DeleteByIdAsync(id);
                await _unitOfWork.CompleteAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to delete client from database");
            }
        }

        public async Task<IEnumerable<ShortClientDTO>> GetAllClientsAsync(CancellationToken cancellation)
        {
            var all_clients = await _unitOfWork.ClientRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ShortClientDTO>>(all_clients);
        }

        public async Task<ClientDTO> GetClientByIdAsync(int id, CancellationToken cancellationToken)
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            return _mapper.Map<ClientDTO>(client);
        }

        public async Task<Models.Client> UpdateClientInSystemAsync(int id, ClientDTO clientDTO, CancellationToken cancellationToken)
        {
            var client_to_update = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (client_to_update == null)
            {
                throw new Exception($"Client with {id} cannot be found");
            }

            try
            {
                await _unitOfWork.ClientRepository.UpdateAsync(_mapper.Map<Models.Client>(clientDTO));
                await _unitOfWork.CompleteAsync(cancellationToken);
                return await _unitOfWork.ClientRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Error while trying to update client from database");
            }
        }
    }
}
