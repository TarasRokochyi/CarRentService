using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.Repositories
{
    public class FineRepository : GenericRepository<Fine>, IFineRepository
    {
        public FineRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
