using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Jurassic.Park.Data;

namespace Jurassic.Park.Pages.Dino
{
    public class DeleteModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public DeleteModel(Jurassic.Park.Data.ApplicationDbContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dinosaurs = await _context.Dinosaurs.FindAsync(id);

            if (Dinosaurs != null)
            {
                _context.Dinosaurs.Remove(Dinosaurs);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
