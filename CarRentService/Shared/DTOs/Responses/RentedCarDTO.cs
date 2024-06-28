namespace CarRentService.Shared.DTOs.Responses
{
    public class RentedCarDTO
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }
        public string CarId { get; set; }
        public CardCarDTO Car { get; set; }  
        public int ClientId { get; set; }
        public ClientDTO Client { get; set; } 
        public int RentalCost { get; set; }
    }
}
