using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Xml;

namespace CarRentService.Server.Models

{
    public class CarRentServiceContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<RegularClient> RegularClients { get; set; }
        public DbSet<Fine> Fines { get; set; }
        public DbSet<RentedCar> RentedCars { get; set; }

        public CarRentServiceContext(DbContextOptions<CarRentServiceContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(b => b.Id);
            modelBuilder.Entity<Client>().HasKey(b => b.Id);
            modelBuilder.Entity<Fine>().HasKey(b => b.Id);
            modelBuilder.Entity<RegularClient>().HasKey(b => b.Id);
            modelBuilder.Entity<RentedCar>().HasKey(b => b.Id);

            modelBuilder.Entity<RentedCar>().HasMany(r => r.Fines).WithMany(f => f.RentedCars).UsingEntity("temp_table");
            modelBuilder.Entity<RentedCar>().HasOne(r => r.Car).WithMany(c => c.RentedCars);
            modelBuilder.Entity<RentedCar>().HasOne(r => r.Client).WithMany(c => c.RentedCars);
        }

    }
}
