using AutoMapper;
using Business.Services.Abstract;
using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;
        private readonly IAmenityService _amenityService;

        public PropertyController(IMapper mapper, IPropertyService service, IAmenityService amenityService)
        {
            _mapper = mapper;
            _service = service;
            _amenityService = amenityService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Amenities = await _amenityService.GetAllAsync();
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyPostDto propertyPostDto)
        {
            //if(!ModelState.IsValid)
            //{
            //    ModelState.AddModelError("", "Can't be null");
            //    return View();
            //}
            ViewBag.Amenities = await _amenityService.GetAllAsync();
            await _service.CreateAsync(propertyPostDto);

            return RedirectToAction(nameof(Index));
        }

        public override bool Equals(object? obj)
        {
            return obj is PropertyController controller &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, controller._mapper);
        }
    }
}
