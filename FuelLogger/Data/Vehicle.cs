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

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Reg. No.")]
        public string RegistrationNumber { get; set; }

        [Required]
        [Display(Name = "Initial mileage")]
        public int InitialOdometerReading { get; set; }

        [Display(Name = "Bad MPG upper limit")]
        public int MPGLimits_Bad { get; set; }

        [Display(Name = "OK MPG upper limit")]
        public int MPGLimits_OK { get; set; }
    }
}

