using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using SengWeb.Data;

namespace SengWeb.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly SengWebContext _context;

        public IndexModel(SengWebContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Category = await _context.Category.ToListAsync();
        }
    }
}