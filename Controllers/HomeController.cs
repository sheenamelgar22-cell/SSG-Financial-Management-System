using Microsoft.AspNetCore.Mvc;

namespace AspNetIdentityLab.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}