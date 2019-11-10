using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThirdLabNet.Models;

namespace ThirdLabNet.Pages.Visits
{
    public class CreateModel : PageModel
    {
        private readonly ThirdLabNet.Models.ApplicationContext _context;

        public CreateModel(ThirdLabNet.Models.ApplicationContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
        ViewData["OperationId"] = new SelectList(_context.Operations, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Visit Visit { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Visits.Add(Visit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}