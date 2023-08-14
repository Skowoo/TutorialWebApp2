using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TutorialWebApp2.Data;
using TutorialWebApp2.Models;

namespace TutorialWebApp2.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly TutorialWebApp2.Data.SchoolContext _context;

        public CreateModel(TutorialWebApp2.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["InstructorID"] = new SelectList(_context.Instructors, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Department Department { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Departments.Add(Department);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
