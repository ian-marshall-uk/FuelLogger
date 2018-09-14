using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FuelLogger.Data
{
    public class FillUp
    {
        [Required]
        public int Id { get; set; }

        [ForeignKey("VehicleId")]
        public virtual Vehicle Vehicle { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Display(Name = "Mileage")]
        public int OdometerReading { get; set; }

        [Required]
        public double Litres { get; set; }

        [Required]
        public double PricePerLitre { get; set; }

        [MaxLength(50)]
        public string Note { get; set; }
    }
}
