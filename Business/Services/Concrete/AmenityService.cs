using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess.Repositories.Abstract;
using DataAccess.Repositories.Concrete;
using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.PropertyDTOs;
using System.Linq.Expressions;

namespace Business.Services.Concrete
{
	public class AmenityService : IAmenityService
	{
		private readonly IAmenityRepository _amenityRepository;
		private readonly IMapper _mapper;

		public AmenityService(IAmenityRepository amenityRepository, IMapper mapper)
		{
			_amenityRepository = amenityRepository;
			_mapper = mapper;
		}

		public async Task CreateAsync(AmenityPostDto amenityPostDto)
		{
			Amenity amenity = _mapper.Map<Amenity>(amenityPostDto);
			await _amenityRepository.CreateAsync(amenity);
		}

		public async Task DeleteAsync(int Id)
		{
			Amenity amenity = await _amenityRepository.GetAsync(f => f.Id == Id);
			_amenityRepository.DeleteAsync(amenity);
		}

		public async Task<List<AmenityGetDto>> GetAllAsync()
		{
			List<Amenity> amenities = await _amenityRepository.GetAllAsync();
			if (amenities is null) throw new NotFoundException(Messages.AmenityNotFound);
			return _mapper.Map<List<AmenityGetDto>>(amenities);
		}

		//public async Task<List<AmenityGetDto>> GetAllAsync(Expression<Func<Amenity, bool>> expression = null, params string[] includes)
		//{
		//	List<Amenity> properties = await _amenityRepository.GetAllAsync(expression, "propertyAmenities");
		//	List<AmenityGetDto> amenityGetDtos = _mapper.Map<List<AmenityGetDto>>(properties);
		//	return amenityGetDtos;
		//}

		public async Task<AmenityGetDto> GetByIdAsync(int Id)
		{
			Amenity amenity = await _amenityRepository.GetAsync(p => p.Id == Id);
			if (amenity is null) throw new NotFoundException(Messages.AmenityNotFound);
			return _mapper.Map<AmenityGetDto>(amenity);
		}

		public async Task UpdateAsync(AmenityUpdateDto amenityUpdateDto)
		{
			Amenity amenity = await _amenityRepository.GetAsync(p => p.Id == amenityUpdateDto.amenityGetDto.Id);
			if (amenity is null) throw new NotFoundException(Messages.AmenityNotFound);
			amenityUpdateDto.amenityGetDto = _mapper.Map<AmenityGetDto>(amenity);
			amenity.Value = amenityUpdateDto.amenityPostDto.Value;
			amenity.Id = amenityUpdateDto.amenityGetDto.Id;
			_amenityRepository.UpdateAsync(amenity);
		}
	}
}
