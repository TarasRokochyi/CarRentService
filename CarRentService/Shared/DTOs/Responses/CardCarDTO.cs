using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentService.Shared.DTOs.Responses
{
    public class CardCarDTO
    {
        public string Id { get; set; }
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string ModelYear { get; set; }
        public string BodyClass { get; set; }
        public double Cost { get; set; }
        public double RentalCost { get; set; }
        public bool IsInUse { get; set; }
    }
}
