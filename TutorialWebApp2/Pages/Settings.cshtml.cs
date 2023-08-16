using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TutorialWebApp2.Pages
{
    public class SettingsModel : PageModel
    {
        private IConfiguration configuration;

        public int studentsPerPage;

        public SettingsModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            studentsPerPage = configuration.GetValue("PageSize", 4);
        }

        public IActionResult OnPost()
        {
            configuration["PageSize"] = Request.Form["studentsOnPageInput"].ToString();

            return RedirectToPage("./Index");
        }
    }
}
