using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThirdLabNet.Models;

namespace ThirdLabNet.Pages.Visits
{
    public class DeleteModel : PageModel
    {
        private readonly ThirdLabNet.Models.ApplicationContext _context;

        public DeleteModel(ThirdLabNet.Models.ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Visit Visit { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Visit = await _context.Visits
                .Include(v => v.Client)
                .Include(v => v.Operation).FirstOrDefaultAsync(m => m.Id == id);

            if (Visit == null)
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

            Visit = await _context.Visits.FindAsync(id);

            if (Visit != null)
            {
                _context.Visits.Remove(Visit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
