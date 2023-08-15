﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using TutorialWebApp2.Data;
using TutorialWebApp2.Models;

namespace TutorialWebApp2.Pages.Departments
{
    public class CreateModel : PageModel
    {
        private readonly SchoolContext _context;

        public CreateModel(SchoolContext context)
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


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) 
                return Page();

            bool budgetParsed = Decimal.TryParse(Request.Form["BudgetString"].ToString()
                .Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                .Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator), out decimal budget);

            if (budgetParsed)
                Department.Budget = budget;
            else
                return Page();

            if (await TryUpdateModelAsync(Department, "Department", s => s.Name, s => s.Budget, s => s.StartDate, s => s.Administrator))
            {
                _context.Departments.Add(Department);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
