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
    public class IndexModel : PageModel
    {
        private readonly _301_fu.Data._301_fuContext _context;

        public IndexModel(_301_fu.Data._301_fuContext context)
        {
            _context = context;
        }

        public IList<Shrine> Shrine { get;set; }

        public async Task OnGetAsync()
        {
            Shrine = await _context.Shrine
                .Include(d => d.region)
                .Include(d => d.medallions)
                .Include(d => d.element)
                .ToListAsync();
        }
    }
}
