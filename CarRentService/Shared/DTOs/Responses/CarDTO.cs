namespace CarRentService.Shared.DTOs.Responses
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Brand { get; set; }
        public double Cost { get; set; }
        public double RentalCost { get; set; }

        // public string type {get; set;} or public string description {get; set;}
    }
}
