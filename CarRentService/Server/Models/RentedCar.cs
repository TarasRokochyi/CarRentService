namespace CarRentService.Server.Models
{
    public class RentedCar
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        
        public string CarCode { get; set; }
        public Car Car { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public List<Fine> Fines { get; set; }
    }
}
