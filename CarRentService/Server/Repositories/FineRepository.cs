using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;

namespace CarRentService.Server.Repositories
{
    public class FineRepository : GenericRepository<Fine>, IFineRepository
    {
        public FineRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
