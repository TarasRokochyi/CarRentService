using CarRentService.Server.Models;
using CarRentService.Server.Repositories.Contracts;

namespace CarRentService.Server.Repositories
{
    public class ClientRepository : GenericRepository<Models.Client>, IClientRepository
    {
        public ClientRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
