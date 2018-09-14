using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;

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
            FillUp = await _context.FillUp.ToListAsync();
        }
    }
}
