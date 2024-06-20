using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;

namespace CarRentService.Server.Repositories
{
    public class RentedCarRepository : GenericRepository<RentedCar>, IRentedCarRepository
    {
        public RentedCarRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
