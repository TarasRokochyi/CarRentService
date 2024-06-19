namespace CarRentService.Server.Models
{
    public class RegularClient
    {
        public int ClientId { get; set; }
        public double Discount { get; set; }

        public Client Client { get; set; }
    }
}
