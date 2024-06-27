namespace CarRentService.DAL.Models
{
    public class RegularClient
    {
        public int Id { get; set; }
        public double Discount { get; set; }

        public Client Client { get; set; }
    }
}
