using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThirdLabNet.Models;

namespace ThirdLabNet.Pages.Visits
{
    public class EditModel : PageModel
    {
        private readonly ThirdLabNet.Models.ApplicationContext _context;

        public EditModel(ThirdLabNet.Models.ApplicationContext context)
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
           ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
           ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Visit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitExists(Visit.Id))
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

        private bool VisitExists(int id)
        {
            return _context.Visits.Any(e => e.Id == id);
        }
    }
}
