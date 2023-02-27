using AutoMapper;
using Business.Services.Abstract;
using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.PropertyDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ProjectRealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;
        private readonly IAmenityService _amenityService;
        private readonly IValidator<PropertyPostDto> _validator;

		public PropertyController(IMapper mapper, IPropertyService service, IAmenityService amenityService, IValidator<PropertyPostDto> validator)
		{
			_mapper = mapper;
			_service = service;
			_amenityService = amenityService;
			_validator = validator;
		}

		public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllAsync());
        }
        [Authorize]
        public async Task<IActionResult> Create()
        {
            ViewBag.Amenities = await _amenityService.GetAllAsync();
            return View(new PropertyPostDto());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PropertyPostDto propertyPostDto)
        {
            ViewBag.Amenities = await _amenityService.GetAllAsync();
            var result = _validator.Validate(propertyPostDto);
            propertyPostDto.Status = "Pending";
            propertyPostDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(propertyPostDto);
            }
            await _service.CreateAsync(propertyPostDto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Single(int Id)
        {
            return View(await _service.GetByIdAsync(Id));
        }

        public override bool Equals(object? obj)
        {
            return obj is PropertyController controller &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, controller._mapper);
        }
    }
}
