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
    public class DeleteModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;

        public DeleteModel(FuelLogger.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FillUp = await _context.FillUp.FindAsync(id);

            if (FillUp != null)
            {
                _context.FillUp.Remove(FillUp);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
