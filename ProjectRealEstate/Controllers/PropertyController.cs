using AutoMapper;
using Business.Services.Abstract;
using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.AppUserDTOs;
using Entities.DTOs.PropertyDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectRealEstate.ViewModels;
using System.Security.Claims;

namespace ProjectRealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;
        private readonly IAmenityService _amenityService;
        private readonly IValidator<PropertyPostDto> _validator;
        private readonly UserManager<AppUser> _userManager;

		public PropertyController(IMapper mapper, IPropertyService service, IAmenityService amenityService, IValidator<PropertyPostDto> validator, UserManager<AppUser> userManager)
		{
			_mapper = mapper;
			_service = service;
			_amenityService = amenityService;
			_validator = validator;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index(int page = 1 , int take = 6)
        {
            var properties = await _service.GetAllPaginated(page, take);

            int pageCount = await GetTotalPages(take);

            PaginateVM<PropertyGetDto> paginate = new PaginateVM<PropertyGetDto>()
            {
                Models = properties,
                CurrentPage = page,
                PageCount = pageCount,
                Previous = page > 1,
                Next= page<pageCount
                
            };
            return View(paginate);
        }

        private async Task<int> GetTotalPages(int take)
        {
			var count = _service.GetAllAsync().Result.Count();
            return (int)Math.Ceiling((decimal)count/ take);
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
            AppUser user = await _userManager.GetUserAsync(HttpContext.User);

            propertyPostDto.User = user;

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

        [Authorize]
        public async Task<IActionResult> Delete(int Id)
        {
            await _service.DeleteByIdAsync(Id);
            return RedirectToAction("Profile","Account");
        }

        [Authorize]
        public async Task<IActionResult> Update(int Id)
        {
            PropertyUpdateDto propertyUpdateDto = new PropertyUpdateDto()
            {
                propertyGetDto = await _service.GetByIdAsync(Id)
			};
			ViewBag.Amenities = await _amenityService.GetAllAsync();
            ViewBag.SelectedAmenities = propertyUpdateDto.propertyGetDto.propertyAmenities;

			return View(propertyUpdateDto); 
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(int Id,PropertyUpdateDto propertyUpdateDto)
        {
            propertyUpdateDto.propertyGetDto = await _service.GetByIdAsync(Id);
			ViewBag.Amenities = await _amenityService.GetAllAsync();
			propertyUpdateDto.propertyPostDto.Status = "Pending";
			propertyUpdateDto.propertyPostDto.UserId = propertyUpdateDto.propertyGetDto.UserId;
            propertyUpdateDto.propertyPostDto.IsDeleted= propertyUpdateDto.propertyGetDto.IsDeleted;
            propertyUpdateDto.propertyPostDto.IsRentOrSale= propertyUpdateDto.propertyGetDto.IsRentOrSale;
			propertyUpdateDto.propertyPostDto.User = propertyUpdateDto.propertyGetDto.User;
			var result = _validator.Validate(propertyUpdateDto.propertyPostDto);

			if (!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    return View(propertyUpdateDto);
                }
            }
            await _service.UpdateAsync(propertyUpdateDto);
            return RedirectToAction("Profile","Account");
        }

        public override bool Equals(object? obj)
        {
            return obj is PropertyController controller &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, controller._mapper);
        }
    }
}
