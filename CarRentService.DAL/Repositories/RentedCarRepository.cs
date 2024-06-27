using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace CarRentService.DAL.Repositories
{
    public class RentedCarRepository : GenericRepository<RentedCar>, IRentedCarRepository
    {
        public RentedCarRepository(CarRentServiceContext context) : base(context)
        {
        }

        public override async Task<IEnumerable<RentedCar>> GetAllAsync()
        {
            return await context.RentedCars.Include(r => r.Client).Include(r => r.Car).ToListAsync();
        }
    }
}
