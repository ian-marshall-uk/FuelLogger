﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;

namespace FuelLogger.Pages.FillUps
{
    public class DetailsModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;

        public DetailsModel(FuelLogger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public FillUp FillUp { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FillUp = await _context.FillUp.FirstOrDefaultAsync(m => m.Id == id);

            if (FillUp == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
