using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace AspNetIdentityLab.Areas.Identity.Pages.Account
{
    [Authorize] // 🔒 Only logged-in users can access
    public class DashboardModel : PageModel
    {
        // Optional: display logged-in user info
        public string UserEmail { get; set; } = "";

        public void OnGet()
        {
            // Get logged-in user email
            UserEmail = User.Identity?.Name ?? "Guest";
        }
    }
}