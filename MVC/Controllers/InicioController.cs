using Microsoft.AspNetCore.Mvc;

namespace ObliProgV5.Controllers
{
    public class InicioController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
