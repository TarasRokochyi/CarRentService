namespace CarRentService.Shared.DTOs.Responses
{
    public class RentedCarDTO
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string CarCode { get; set; }
        public int ClientId { get; set; }
    }
}
