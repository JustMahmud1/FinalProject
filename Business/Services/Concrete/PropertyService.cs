﻿using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Business.Utilities.Extensions;
using Core.Utilities.Exceptions;
using DataAccess;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq.Expressions;
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

		public PropertyService(IPropertyRepository propertyRepository, IMapper mapper, IWebHostEnvironment env, IAmenityService amenityService, AppDbContext context)
		{
			_propertyRepository = propertyRepository;
			_mapper = mapper;
			_env = env;
			_amenityService = amenityService;
			_context = context;
		}

		public async Task CreateAsync(PropertyPostDto propertyPostDto)
		{
			Property property = _mapper.Map<Property>(propertyPostDto);

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


			await _propertyRepository.CreateAsync(property);
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
			List<Property> properties = await _propertyRepository.GetAllAsync(p=>!p.IsDeleted,"PropertyAmenity.Amenity");
			if (properties is null) throw new NotFoundException(Messages.PropertyNotFound);
			return _mapper.Map<List<PropertyGetDto>>(properties);
		}

		//public async Task<List<PropertyGetDto>> GetAllAsync(Expression<Func<Property, bool>> expression = null, params string[] includes)
		//{
		//	List<Property> properties = await _propertyRepository.GetAllAsync(expression, "propertyAmenities");
		//	List<PropertyGetDto> propertyGetDtos = _mapper.Map<List<PropertyGetDto>>(properties);
		//	return propertyGetDtos;
		//}

		public async Task<PropertyGetDto> GetByIdAsync(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id);
			if (property is null) throw new NotFoundException(Messages.PropertyNotFound);
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
			property = _mapper.Map<Property>(propertyUpdateDto.propertyPostDto);
			_propertyRepository.UpdateAsync(property);
		}
	}
}
