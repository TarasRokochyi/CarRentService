﻿namespace CarRentService.DAL.Models
{
    public class RentedCar
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsReturned { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public double RentalCost { get; set; }

        public List<Fine> Fines { get; set; }
    }
}
