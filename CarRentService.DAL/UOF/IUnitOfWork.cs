﻿using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.UOF
{
    public interface IUnitOfWork
    {
        ICarRepository CarRepository { get; }
        IClientRepository ClientRepository { get; }
        IFineRepository FineRepository { get; }
        IRegularClientRepository RegularClientRepository { get; }
        IRentedCarRepository RentedCarRepository { get; }

        Task<int> CompleteAsync(CancellationToken cancellationToken);
    }
}
