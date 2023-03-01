using Business.Services.Abstract;
using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Mvc;
using ProjectRealEstate.ViewModels;
using System.Diagnostics;

namespace ProjectRealEstate.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPropertyService _propertyService;
		private readonly ISliderService _sliderService;

		public HomeController(IPropertyService propertyService, ISliderService sliderService)
		{
			_propertyService = propertyService;
			_sliderService = sliderService;
		}

		public async Task<IActionResult> Index()
		{
			HomeVM homeVM = new HomeVM()
			{
				sliderGetDtos = await _sliderService.GetOnlyApproved(),
				propertyGetDtos =  _propertyService.GetAllAsync().Result.OrderByDescending(p => p.Id).Take(4).ToList()
			};
			return View(homeVM);
		}

	}
}