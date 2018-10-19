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

        public IActionResult OnGet()
        {
            MyFillUp = new FillUp();

            MyFillUp.Date = DateTime.Now;
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

            MyFillUp.Vehicle = _context.Vehicle.FirstOrDefault(v => v.Id.ToString() == SelectedVehicleId);
            _context.FillUp.Add(MyFillUp);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}