using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentService.Shared.DTOs.Requests
{
    public class CarRequestDTO
    {
        [Required(ErrorMessage = "VIN code is required")]
        [MaxLength(17)]
        [MinLength(17)]
        public string VINCode { get; set; }

        public double Cost { get; set; }

        [Required(ErrorMessage = "Rental cost is required")]
        public double RentalCost { get; set; }
    }
}
