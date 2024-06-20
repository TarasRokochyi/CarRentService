using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;

namespace CarRentService.Server.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
