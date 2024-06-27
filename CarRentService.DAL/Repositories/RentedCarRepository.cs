using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.Repositories
{
    public class RentedCarRepository : GenericRepository<RentedCar>, IRentedCarRepository
    {
        public RentedCarRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
