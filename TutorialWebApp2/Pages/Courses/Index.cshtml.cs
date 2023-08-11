using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TutorialWebApp2.Data;
using TutorialWebApp2.Models;

namespace TutorialWebApp2.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly TutorialWebApp2.Data.SchoolContext _context;

        public IndexModel(TutorialWebApp2.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Courses = await _context.Courses
                .Include(c => c.Department)
                .AsNoTracking() //No-tracking queries are useful when the results are used in a read-only scenario.
                .ToListAsync();
            }
        }
    }
}
