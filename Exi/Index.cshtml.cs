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
    public class IndexModel : PageModel
    {
        private readonly Jurassic.Park.Data.ApplicationDbContext _context;

        public IndexModel(Jurassic.Park.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Exibits> Exibits { get;set; }

        public async Task OnGetAsync()
        {
            Exibits = await _context.Exibits.ToListAsync();
        }
    }
}
