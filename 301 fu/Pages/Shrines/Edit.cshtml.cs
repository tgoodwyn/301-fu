using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _301_fu.Data;
using _301_fu.Models;

namespace _301_fu.Pages.Shrines
{
    public class EditModel : PageModel
    {
        private readonly _301_fu.Data._301_fuContext _context;

        public EditModel(_301_fu.Data._301_fuContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Shrine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShrineExists(Shrine.id))
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

        private bool ShrineExists(int id)
        {
            return _context.Shrine.Any(e => e.id == id);
        }
    }
}
