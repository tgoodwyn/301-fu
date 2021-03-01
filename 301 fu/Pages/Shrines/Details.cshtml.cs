using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using _301_fu.Data;
using _301_fu.Models;

namespace _301_fu.Pages.Shrines
{
    public class DetailsModel : PageModel
    {
        private readonly _301_fu.Data._301_fuContext _context;

        public DetailsModel(_301_fu.Data._301_fuContext context)
        {
            _context = context;
        }

        public Shrine Shrine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Shrine = await _context.Shrine.FirstOrDefaultAsync(m => m.id == id);

            if (Shrine == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
