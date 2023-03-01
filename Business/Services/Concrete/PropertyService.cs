using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Extensions;
using Core.Utilities.Exceptions;
using DataAccess;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.AppUserDTOs;
using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml.Linq;

namespace Business.Services.Concrete
{
	public class PropertyService : IPropertyService
	{
		private readonly IPropertyRepository _propertyRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;
		private readonly IAmenityService _amenityService;
		private readonly AppDbContext _context;
		private readonly UserManager<AppUser> _userManager;

		public PropertyService(IPropertyRepository propertyRepository, IMapper mapper, IWebHostEnvironment env, IAmenityService amenityService, AppDbContext context, UserManager<AppUser> userManager)
		{
			_propertyRepository = propertyRepository;
			_mapper = mapper;
			_env = env;
			_amenityService = amenityService;
			_context = context;
			_userManager = userManager;
		}

		public async Task CreateAsync(PropertyPostDto propertyPostDto)
		{
			Property property = _mapper.Map<Property>(propertyPostDto);

			await _propertyRepository.CreateAsync(property);

			foreach (var item in propertyPostDto.FormFiles)
			{
				PropertyImage propertyImage = new PropertyImage
				{
					Property = property,
					Name = item.CreateFile(_env.WebRootPath, "assets/img/Property"),
					IsMain = property.Images.Count > 0 ? false : true,
				};
				property.Images.Add(propertyImage);
			}
			foreach (var item in propertyPostDto.AmenitiesIds)
			{
				PropertyAmenity propertyAmenity = new PropertyAmenity
				{
					PropertyId = property.Id,
					AmenityId = item
				};
				_context.PropertyAmenities.Add(propertyAmenity);
			}
			property.IsRentOrSale = true;
			property.User = _context.Users.Where(u => u.Id == propertyPostDto.UserId).FirstOrDefault();
			_context.SaveChanges();
		}

		public async Task DeleteByIdAsync(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id);
			if (property is null)
			{
				throw new NotFoundException(Messages.PropertyNotFound);
			}
			_propertyRepository.DeleteAsync(property);
		}

		public async Task<List<PropertyGetDto>> GetAllAsync()
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(p => !p.IsDeleted && p.Status == "Approved", "propertyAmenities", "Images");
			if (properties is null) throw new NotFoundException(Messages.PropertyNotFound);
			foreach (var item in properties)
			{
				AppUserGetDto appUserGetDto = _mapper.Map<AppUserGetDto>(_context.Users.Where(u => u.Id == item.UserId).FirstOrDefault());
			}
			return _mapper.Map<List<PropertyGetDto>>(properties);
		}


		public async Task<List<PropertyGetDto>> GetAllAsync(Expression<Func<Property, bool>> expression = null)
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(expression, "propertyAmenities","Images");
			List<PropertyGetDto> propertyGetDtos = _mapper.Map<List<PropertyGetDto>>(properties);
			return propertyGetDtos;
		}

		public async Task<PropertyGetDto> GetByIdAsync(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id, "propertyAmenities.Amenity", "Images");
			if (property is null) throw new NotFoundException(Messages.PropertyNotFound);
			AppUserGetDto appUserGetDto = _mapper.Map<AppUserGetDto>(_context.Users.Where(u => u.Id == property.UserId).FirstOrDefault());
			return _mapper.Map<PropertyGetDto>(property);
		}

		public async Task<PropertyGetDto> GetByNameAsync(string name)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Title == name);
			if (property is null) throw new NotFoundException(Messages.PropertyNotFound);
			return _mapper.Map<PropertyGetDto>(property);
		}

		public async Task UpdateAsync(PropertyUpdateDto propertyUpdateDto)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == propertyUpdateDto.propertyGetDto.Id);
			if (property is null) throw new NotFoundException(Messages.PropertyNotFound);
			//Bir bütöv gün dirəşdim map etmədi düzgün əl ilə yazmalı oldum.
			property.Id = propertyUpdateDto.propertyGetDto.Id;
			property.propertyAmenities = null;
			property.Title = propertyUpdateDto.propertyPostDto.Title;
			property.Price = (double)propertyUpdateDto.propertyPostDto.Price;
			property.Area = (double)propertyUpdateDto.propertyPostDto.Area;
			property.PropertyType = propertyUpdateDto.propertyPostDto.PropertyType;
			property.IsFeatured = propertyUpdateDto.propertyGetDto.IsFeatured;
			property.HasGarage = propertyUpdateDto.propertyPostDto.HasGarage;
			property.Location = propertyUpdateDto.propertyPostDto.Location;
			property.Rooms = propertyUpdateDto.propertyPostDto.Rooms;
			property.Description = propertyUpdateDto.propertyPostDto.Description;
			if (propertyUpdateDto.propertyPostDto.FormFiles != null)
			{
				foreach (var item in propertyUpdateDto.propertyPostDto.FormFiles)
				{
					PropertyImage propertyImage = new PropertyImage
					{
						Property = property,
						Name = item.CreateFile(_env.WebRootPath, "assets/img/Property"),
						IsMain = property.Images.Count > 0 ? false : true,
					};
					property.Images.Add(propertyImage);
				}
			}
			else if(propertyUpdateDto.propertyPostDto.FormFiles== null)
			{
				property.Images = propertyUpdateDto.propertyGetDto.Images;
			}

			foreach (var item in propertyUpdateDto.propertyPostDto.AmenitiesIds)
			{
				PropertyAmenity propertyAmenity = new PropertyAmenity
				{
					PropertyId = propertyUpdateDto.propertyGetDto.Id,
					AmenityId = item
				};
				_context.PropertyAmenities.Add(propertyAmenity);
			}
			_context.SaveChanges();
		}
		public async Task<List<PropertyGetDto>> GetByStatus(string status)
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(p => p.Status == status);
			foreach (var item in properties)
			{
				AppUserGetDto appUserGetDto = _mapper.Map<AppUserGetDto>(_context.Users.Where(u => u.Id == item.UserId).FirstOrDefault());
			}
			return _mapper.Map<List<PropertyGetDto>>(properties);
		}

		public async Task Approve(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id, "propertyAmenities.Amenity", "Images");
			property.Status = "Approved";
			_context.SaveChanges();
		}

		public async Task Reject(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id, "propertyAmenities.Amenity", "Images");
			property.Status = "Rejected";
			_context.SaveChanges();
		}

		public async Task<List<PropertyGetDto>> GetAllPaginated(int number, int size)
		{
			List<Property> properties = await _propertyRepository.GetAllPaginated(number, size, x => x.Id, p => !p.IsDeleted && p.Status == "Approved", "propertyAmenities", "Images");
			return _mapper.Map<List<PropertyGetDto>>(properties);
		}

		public async Task<List<PropertyGetDto>> GetByUser(string name)
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(p => p.User.UserName == name, "propertyAmenities", "Images");
			foreach (var item in properties)
			{
				AppUserGetDto appUserGetDto = _mapper.Map<AppUserGetDto>(_context.Users.Where(u => u.Id == item.UserId).FirstOrDefault());
			}
			return _mapper.Map<List<PropertyGetDto>>(properties);
		}

		public async Task<bool> UpdatePropetyIsFeatured (int propertyId, bool isFeatured)
		{
			var property = await _propertyRepository.GetAsync(p => p.Id == propertyId);
			if (property != null)
			{
				return false;
			}
			property.IsFeatured=isFeatured;
			_propertyRepository.UpdateAsync(property);
			return true;
		}
	}
}
