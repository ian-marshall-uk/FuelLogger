﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FuelLogger.Data;
using Microsoft.AspNetCore.Identity;

namespace FuelLogger.Pages.FillUps
{
    public class CreateModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _user;

        public CreateModel(FuelLogger.Data.ApplicationDbContext context, UserManager<ApplicationUser> user)
        {
            _context = context;
            _user = user;
            AvailableVehicles = new List<SelectListItem>();

            foreach (var vehicle in _context.Vehicle)
            {
                AvailableVehicles.Add(new SelectListItem(vehicle.Name, vehicle.Id.ToString()));
            }
        }

        [BindProperty]
        public List<SelectListItem> AvailableVehicles { get; set; }

        public IActionResult OnGet(int? id)
        {
            var vehicle = _context.Vehicle.FirstOrDefault(v => v.Id == id);

            MyFillUp = new FillUp();

            MyFillUp.Date = DateTime.Now;
            MyFillUp.Vehicle = vehicle;

            return Page();
        }

        [BindProperty]
        public FillUp MyFillUp { get; set; }
        [BindProperty]
        public string SelectedVehicleId { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            MyFillUp.User = await _user.GetUserAsync(User);

            int lastOdometerReading = 0;
            var lastFillUp = _context.FillUp.OrderByDescending(ff => ff.Date).FirstOrDefault(f => f.Vehicle.Id == MyFillUp.Vehicle.Id);
            if (lastFillUp != null)
            {
                lastOdometerReading = lastFillUp.OdometerReading;
            }
            else
            {
                lastOdometerReading = MyFillUp.Vehicle.InitialOdometerReading;
            }

            MyFillUp.MileageDelta = MyFillUp.OdometerReading - lastOdometerReading;
            MyFillUp.MPG = (MyFillUp.MileageDelta / (MyFillUp.Litres / 4.54));
            _context.FillUp.Add(MyFillUp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", new { Id = MyFillUp.Vehicle.Id});
        }
    }
}