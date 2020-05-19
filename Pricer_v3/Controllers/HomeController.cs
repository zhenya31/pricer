using Microsoft.AspNetCore.Mvc;

namespace Pricer_v3.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}