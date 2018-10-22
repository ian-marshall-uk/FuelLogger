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

        public virtual ApplicationUser User { get; set; }
    
        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Mileage")]
        public int OdometerReading { get; set; }

        [Required]
        public double Litres { get; set; }

        [Required]
        public double PricePerLitre { get; set; }

        [MaxLength(50)]
        public string Note { get; set; }

        public int MileageDelta { get; set; }
        public double MPG { get; set; }
    }
}
