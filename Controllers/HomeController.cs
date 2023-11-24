using lr11.Filters;
using Microsoft.AspNetCore.Mvc;

namespace lr11.Controllers
{
    public class HomeController : Controller
    {
        [LogActionFilter]
        public IActionResult Index()
        {
            return View();
        }

        [UniqueUsersFilter]
        public IActionResult Privacy()
        {
            return View("Privacy");
        }
    }
}