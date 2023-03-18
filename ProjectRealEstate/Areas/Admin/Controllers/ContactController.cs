using Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;

		public ContactController(IContactService service)
		{
			_service = service;
		}

		public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public async Task<IActionResult> Read(int Id)
        {
            await _service.Read(Id);
            return RedirectToAction(nameof(Index));
        }
    }
}
