using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.UOF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarRentServiceContext context;
        public ICarRepository CarRepository { get; }
        public IClientRepository ClientRepository { get; }
        public IFineRepository FineRepository { get; }
        public IRegularClientRepository RegularClientRepository { get; }
        public IRentedCarRepository RentedCarRepository { get; }

        public UnitOfWork(
            CarRentServiceContext context,
            ICarRepository carRepository,
            IClientRepository clientRepository,
            IFineRepository fineRepository,
            IRegularClientRepository regularClientRepository,
            IRentedCarRepository rentedCarRepository)
        {
            this.context = context;
            CarRepository = carRepository;
            ClientRepository = clientRepository;
            FineRepository = fineRepository;
            RegularClientRepository = regularClientRepository;
            RentedCarRepository = rentedCarRepository;
        }

        public async Task<int> CompleteAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }
    }
}
