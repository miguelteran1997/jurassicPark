using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Jurassic.Park.Data;

namespace Jurassic.Park.Pages.Exi
{
    public class CreateModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public CreateModel(Jurassic.Park.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Exibits Exibits { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Exibits.Add(Exibits);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}