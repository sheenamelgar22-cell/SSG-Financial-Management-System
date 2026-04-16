using Microsoft.AspNetCore.Mvc;
using AspNetIdentityLab.Models;

namespace AspNetIdentityLab.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
       public IActionResult Login()
{
        return Redirect("/Identity/Account/Login");
}
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // login logic here later
            return RedirectToAction("Index");
        }
    }
}