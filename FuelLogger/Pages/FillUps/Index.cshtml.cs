using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FuelLogger.Pages.FillUps
{
    public class IndexModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public IndexModel(FuelLogger.Data.ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;

        }

        [BindProperty]
        public List<SelectListItem> AvailableVehicles { get; set; }
        [BindProperty]
        public string SelectedVehicleId { get; set; }

        public IList<FillUp> FillUp { get;set; }

        public async Task OnGetAsync(int? id)
        {
            if (id.HasValue)
            {
                SelectedVehicleId = id.Value.ToString();
            }
            else
            {
                SelectedVehicleId = _context.Vehicle.Include(v => v.User)
                    .FirstOrDefault(v => v.User.Id == _user.GetUserAsync(User).Result.Id)?.Id.ToString();
            }

            AvailableVehicles = new List<SelectListItem>();

            foreach (var vehicle in _context.Vehicle)
            {
                AvailableVehicles.Add(new SelectListItem(vehicle.Name, vehicle.Id.ToString()));
            }

            if (SelectedVehicleId != null)
            {
                FillUp = new List<FillUp>();
                FillUp = _context.FillUp.Include(f => f.Vehicle).Where(f => f.Vehicle.Id == Convert.ToInt32(SelectedVehicleId)).ToList();
            }
            else
            {
                FillUp = new List<FillUp>();
            }
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