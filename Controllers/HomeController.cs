using Microsoft.AspNetCore.Mvc;

namespace LeadsSMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: / or /Home/Index
        public IActionResult Index()
        {
            return View();
        }
    }
}
