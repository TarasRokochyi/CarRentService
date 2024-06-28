using CarRentService.DAL.Models;

namespace CarRentService.DAL.Repositories.Contracts
{
    public interface IRentedCarRepository : IGenericRepository<RentedCar>
    {
        Task<IEnumerable<RentedCar>> GetAllAsync(string entityHistory, int entityId, string orderby);
    }
}
