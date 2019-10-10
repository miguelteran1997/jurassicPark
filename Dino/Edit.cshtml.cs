using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Jurassic.Park.Data;

namespace Jurassic.Park.Pages.Dino
{
    public class EditModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public EditModel(Jurassic.Park.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Dinosaurs Dinosaurs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinosaurs = await _context.Dinosaurs
                .Include(d => d.Exi).FirstOrDefaultAsync(m => m.DID == id);

            if (Dinosaurs == null)
            {
                return NotFound();
            }
           ViewData["EID"] = new SelectList(_context.Set<Exibits>(), "EID", "EID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Dinosaurs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DinosaursExists(Dinosaurs.DID))
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

        private bool DinosaursExists(int id)
        {
            return _context.Dinosaurs.Any(e => e.DID == id);
        }
    }
}
