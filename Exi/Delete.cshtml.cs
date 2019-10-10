using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jurassic.Park.Data;

namespace Jurassic.Park.Pages.Exi
{
    public class DeleteModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public DeleteModel(Jurassic.Park.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Exibits = await _context.Exibits.FindAsync(id);

            if (Exibits != null)
            {
                _context.Exibits.Remove(Exibits);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
