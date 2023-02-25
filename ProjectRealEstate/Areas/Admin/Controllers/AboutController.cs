using Business.Services.Abstract;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _aboutService.Get());
        }

        public async Task<IActionResult> Update()
        {
            AboutUpdateDto aboutUpdateDto = new AboutUpdateDto()
            {
                aboutGetDto = await _aboutService.Get()
            };

            return View(aboutUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Update(AboutUpdateDto aboutUpdateDto) 
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("aboutUpdateDto", "Can't be null");
            }
            aboutUpdateDto.aboutGetDto = await _aboutService.Get();
            await _aboutService.UpdateAsync(aboutUpdateDto);
            return RedirectToAction(nameof(Index));
        }

    }
}
