namespace CarRentService.DAL.Models
{
    public class Fine
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }

        public List<RentedCar> RentedCars { get; set; }
    }
}
