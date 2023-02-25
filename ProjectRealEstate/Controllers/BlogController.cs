using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
