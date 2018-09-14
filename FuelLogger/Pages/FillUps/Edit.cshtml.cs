using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FuelLogger.Data;

namespace FuelLogger.Pages.FillUps
{
    public class EditModel : PageModel
    {
        private readonly FuelLogger.Data.ApplicationDbContext _context;

        public EditModel(FuelLogger.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(FillUp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FillUpExists(FillUp.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FillUpExists(int id)
        {
            return _context.FillUp.Any(e => e.Id == id);
        }
    }
}
