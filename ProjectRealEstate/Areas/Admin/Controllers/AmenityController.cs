using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class AmenityController : Controller
	{
		private readonly IAmenityService _amenityService;

		public AmenityController(IAmenityService amenityService)
		{
			_amenityService = amenityService;
		}

		public async Task<IActionResult> Index()
		{ 
			return View(await _amenityService.GetAllAsync());
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(AmenityPostDto amenityPostDto)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Can't be null");
				return View(amenityPostDto);
			}
			await _amenityService.CreateAsync(amenityPostDto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Update(int Id)
		{
			AmenityUpdateDto amenityUpdateDto = new AmenityUpdateDto() { amenityGetDto = await _amenityService.GetByIdAsync(Id) };

			return View(amenityUpdateDto);
		}

		[HttpPost]
		public async Task<IActionResult> Update(AmenityUpdateDto amenityUpdateDto)
		{
			await _amenityService.UpdateAsync(amenityUpdateDto);
			return RedirectToAction(nameof(Index));
		}

		public async Task<IActionResult> Delete(int Id)
		{
			if (await _amenityService.GetByIdAsync(Id) == null) throw new NotFoundException(Messages.AmenityNotFound);
		    await _amenityService.DeleteAsync(Id);
			return RedirectToAction(nameof(Index));
		}

	}
}
