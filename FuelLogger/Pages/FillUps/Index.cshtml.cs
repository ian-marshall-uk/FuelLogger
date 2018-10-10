using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FuelLogger.Pages.FillUps
{
    public class IndexModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;

        public IndexModel(FuelLogger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<FillUp> FillUp { get;set; }

        public async Task OnGetAsync()
        {
            int VehicleId = 1;
            var userID = "e22dbd0c-5e6e-4f7a-a86a-8fd693ca1ff0";

            FillUp = await _context.FillUp.Where(f => f.Vehicle.Id == VehicleId && f.UserId == userID).ToListAsync();
        }
    }
}



/*
 * public void DoSomething()
        {
            List<FillUp> OrderedFillUps = Context.Vehicles.FirstOrDefault(veh => veh.Registration == "NV07 EOX").FillUps.OrderBy(fill => fill.Date).ToList();

            if (OrderedFillUps.Count < 2)
            {
                throw new Exception("You need at least two FillUps to do this calculation");
            }

            FillUp LatestFillup = OrderedFillUps[0];
            FillUp PreviousFillup = OrderedFillUps[1];

            int VehId = LatestFillup.ForVehicle.Id;
            DateTime date = LatestFillup.Date;
            decimal OdometerReading = LatestFillup.OdometerReading;
            int Litres = LatestFillup.Litres;
            decimal PricePerLitre = LatestFillup.PricePerLitre;
            decimal MileageDelta = LatestFillup.MileageDelta(PreviousFillup.OdometerReading);
            decimal MPG = LatestFillup.MPG(PreviousFillup.OdometerReading);
        }

    public class FillUp
    {
        public int Id;
        public DateTime Date;
        public decimal OdometerReading;
        public int Litres;
        public decimal PricePerLitre;
        public Vehicle ForVehicle;


        public decimal MileageDelta(decimal? PreviousOdometerReading)
        {
            if (!PreviousOdometerReading.HasValue)
            {
                throw new Exception("You need at least two FullUps to use this function. PreviousOdometerReading cannot be null");
            }

            return OdometerReading - PreviousOdometerReading.Value;
        }

        public decimal MPG(decimal? PreviousOdometerReading)
        {
            if (!PreviousOdometerReading.HasValue)
            {
                throw new Exception("You need at least two FullUps to use this function. PreviousOdometerReading cannot be null");
            }

            decimal delta = MileageDelta(PreviousOdometerReading);

            return (delta / (Litres / (decimal)4.54));
        }
    }
*/