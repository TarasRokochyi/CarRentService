namespace CarRentService.Server.Models
{
    public class Car
    {
        public string Code { get; set; }
        public string Brand { get; set; }
        public double Cost { get; set; }
        public double RentalCost { get; set; }

        public List<RentedCar> RentedCars { get; set; }
        // public string type {get; set;} or public string description {get; set;}

    }
}
