using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThirdLabNet.Models;

namespace ThirdLabNet.Pages.Visits
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        public IList<Visit> Visit { get;set; }

        public async Task OnGetAsync()
        {
            Visit = await _context.Visits
                .Include(v => v.Client)
                .Include(v => v.Operation).ToListAsync();
        }
    }
}
