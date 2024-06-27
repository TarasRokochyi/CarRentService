using CarRentService.DAL.Models;
using CarRentService.DAL.Repositories.Contracts;

namespace CarRentService.DAL.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(CarRentServiceContext context) : base(context)
        {
        }
    }
}
