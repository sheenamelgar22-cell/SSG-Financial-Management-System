using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterStep2Model : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        return RedirectToPage("Login");
    }
}