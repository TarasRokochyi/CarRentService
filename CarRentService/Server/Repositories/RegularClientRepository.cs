using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;

namespace CarRentService.Server.Repositories
{
    public class RegularClientRepository : GenericRepository<RegularClient>, IRegularClientRepository
    {
        public RegularClientRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
