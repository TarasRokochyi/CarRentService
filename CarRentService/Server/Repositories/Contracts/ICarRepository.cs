using CarRentService.Server.Models;

namespace CarRentService.Server.Repositories.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<Car> GetByCodeAsync(string code);
    }
}
