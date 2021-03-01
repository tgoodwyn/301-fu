using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using _301_fu.Data;
using _301_fu.Models;

namespace _301_fu.Pages.Shrines
{
    public class CreateModel : PageModel
    {
        private readonly _301_fu.Data._301_fuContext _context;

        public CreateModel(_301_fu.Data._301_fuContext context)
        {
            _context = context;
            //checkedBoxes = new bool[len];
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Shrine shrine { get; set; }
        [BindProperty]
        public Region region { get; set; }
        [BindProperty]
        public Element element { get; set; }

        //public List<Medallion> medallions 
        static int len = Medallion.options.Length;
        [BindProperty]
        public List<int> checkedBoxes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // translating checked boxes to medallion objects
            List<Medallion> medallions = new List<Medallion>();
            foreach (int i in checkedBoxes)
            {
                medallions.Add(new Medallion { labelIdx = i });
            }

            // setting the shrineID's of all the dependent objects to that of the shrine
            region.shrineId = shrine.id;
            element.shrineId = shrine.id;
            foreach (Medallion m in medallions)
            {
                m.shrineId = shrine.id;
                _context.Medallion.Add(m);

            }

            // setting the shrine properties to each dependent object
            shrine.region = region;
            shrine.element = element;
            shrine.medallions = medallions;


            // adding everything to the database
            _context.Shrine.Add(shrine);
            _context.Region.Add(region);
            _context.Element.Add(element);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
