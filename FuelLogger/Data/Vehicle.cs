using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLogger.Data
{
    public class Vehicle
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Reg. No.")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Initial mileage")]
        public int InitialOdometerReading { get; set; }
    }
}
