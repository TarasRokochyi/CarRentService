using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.Repositories
{
    public class RegularClientRepository : GenericRepository<RegularClient>, IRegularClientRepository
    {
        public RegularClientRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
