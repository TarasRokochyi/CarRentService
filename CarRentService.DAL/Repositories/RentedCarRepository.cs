﻿using CarRentService.DAL.Models;
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

        public async Task<IEnumerable<RentedCar>> GetAllAsync(string entityHistory, int entityId, string orderby)
        {
            IQueryable<RentedCar> query = context.RentedCars;
            if (entityHistory == "car" && entityId != 0)
                query = query.Where(r => r.CarId == entityId);

            if(entityHistory == "client" && entityId != 0)
                query = query.Where(r => r.ClientId == entityId);

            query = query.Include(r => r.Car).Include(r => r.Client);
            query = query.OrderBy(r => r.RentDate);

            return await query.ToListAsync();
        }
        public override Task<RentedCar> GetByIdAsync(int id)
        {
            var query =  context.RentedCars.Where(r => r.Id == id).Include(r => r.Client).Include(r => r.Car);
            return query.FirstOrDefaultAsync();
        }
    }
}
