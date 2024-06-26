using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace CarRentService.Server.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(CarRentServiceContext context) : base(context)
        {
        }

        public async Task<Car> GetByCodeAsync(string code)
        {
            return await table.FirstAsync(c => c.VIN == code);
        }
    }
}
