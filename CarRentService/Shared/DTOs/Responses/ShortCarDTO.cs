using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentService.Shared.DTOs.Responses
{
    public class ShortCarDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Cost { get; set; }
        public double RentalCost { get; set; }
    }
}
