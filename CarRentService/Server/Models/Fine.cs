namespace CarRentService.Server.Models
{
    public class Fine
    {
        public int Code { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public List<RentedCar> RentedCars { get; set; }
    }
}
