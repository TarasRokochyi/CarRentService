namespace CarRentService.Server.DTOs
{
    public class RentedCarDTO
    {
        public int RentId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarCode { get; set; }
        public int ClientId { get; set; }
    }
}
