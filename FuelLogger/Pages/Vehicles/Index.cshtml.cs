using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;

namespace FuelLogger.Pages.Vehicles
{
    public class IndexModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;

        public IndexModel(FuelLogger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Vehicle> Vehicle { get;set; }

        public async Task OnGetAsync()
        {
            Vehicle = await _context.CategoryType.ToListAsync();
        }
    }
}
