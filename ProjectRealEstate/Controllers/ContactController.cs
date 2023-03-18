using Business.Services.Abstract;
using Entities.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Send(ContactPostDto contactPostDto)
        {
            await _service.Send(contactPostDto);
            return RedirectToAction(nameof(Index));
        }
    }
}
