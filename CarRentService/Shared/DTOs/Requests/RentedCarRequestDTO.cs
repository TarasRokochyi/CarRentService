using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentService.Shared.DTOs.Requests
{
    public class RentedCarRequestDTO
    {
        public int CarId { get; set; }
        public int ClientId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate {get; set;}

    }
}
