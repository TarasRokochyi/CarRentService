namespace CarRentService.DAL.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string BodyClass { get; set; }
        public double Cost { get; set; }
        public double RentalCost { get; set; }
        public bool IsInUse { get; set; }

        public List<RentedCar> RentedCars { get; set; }
        // public string type {get; set;} or public string description {get; set;}

    }
}
