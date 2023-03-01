using Business.Services.Abstract;
using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using Entities.DTOs.SliderDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRealEstate.ViewModels;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class SliderController : Controller
	{
		private readonly ISliderService _sliderService;

		public SliderController(ISliderService sliderService)
		{
			_sliderService = sliderService;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _sliderService.GetAllAsync());
		}

		public async Task<IActionResult> CurrentSliders()
		{
			return View(await _sliderService.GetOnlyApproved());
		}

		public async Task<IActionResult> MakeSlider(int Id)
		{
			await _sliderService.MakeSlider(Id);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> DeleteSlider(int Id)
		{
			await _sliderService.DeleteSlider(Id);
			return RedirectToAction(nameof(CurrentSliders));
		}



	}
}
