using CarRentService.DAL.Models;

namespace CarRentService.DAL.Repositories.Contracts
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<Car> GetByCodeAsync(string code);
    }
}
