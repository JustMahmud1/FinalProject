using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
