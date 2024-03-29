﻿using Business.Services.Abstract;
using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectRealEstate.ViewModels;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class PropertyController : Controller
	{
		private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        public async Task<IActionResult> Index()
		{
			List<PropertyGetDto> property = await _propertyService.GetByStatus("Pending");
			return View(property);
		}

        public async Task<IActionResult> AllProperties()
        {
            return View(await _propertyService.GetAllAsync());
        }

        public async Task<IActionResult> Approve(int Id)
        {
            await _propertyService.Approve(Id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Approved()
        {
            List<PropertyGetDto> property = _propertyService.GetByStatus("Approved").Result.OrderByDescending(i => i.Id).ToList();
            return View(property);
        }

        public async Task<IActionResult> Reject(int Id)
        {
            await _propertyService.Reject(Id);
            return RedirectToAction(nameof(Approved));
        }

        public async Task<IActionResult> Rejected()
        {
            List<PropertyGetDto> property = await _propertyService.GetByStatus("Rejected");
            return View(property);
        }

		public async Task<IActionResult> Delete(int Id)
		{
			await _propertyService.DeleteByIdAsync(Id);
			return RedirectToAction(nameof(AllProperties));
		}

	}
}
