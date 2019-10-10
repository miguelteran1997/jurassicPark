using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jurassic.Park.Data;

namespace Jurassic.Park.Pages.Exi
{
    public class EditModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public EditModel(Jurassic.Park.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Exibits Exibits { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exibits = await _context.Exibits.FirstOrDefaultAsync(m => m.EID == id);

            if (Exibits == null)
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

            _context.Attach(Exibits).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExibitsExists(Exibits.EID))
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

        private bool ExibitsExists(int id)
        {
            return _context.Exibits.Any(e => e.EID == id);
        }
    }
}
