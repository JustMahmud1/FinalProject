using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Constants;
using Core.Utilities.Exceptions;
using DataAccess;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.PropertyDTOs;
using Entities.DTOs.SliderDTOs;

namespace Business.Services.Concrete
{
	public class SliderService : ISliderService
	{
		private readonly ISliderRepository _repository;
		private readonly IPropertyRepository _propertyRepository;
		private readonly IMapper _mapper;
		private readonly AppDbContext _context;

		public SliderService(ISliderRepository repository, IPropertyRepository propertyRepository, IMapper mapper, AppDbContext context)
		{
			_repository = repository;
			_propertyRepository = propertyRepository;
			_mapper = mapper;
			_context = context;
		}
		public async Task<List<SliderGetDto>> GetAllAsync()
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(p=>!p.IsDeleted&&p.Status=="Approved"&&!p.IsFeatured, "propertyAmenities", "Images");
			if (properties is null) throw new NotFoundException(Messages.PropertyNotFound);
			return _mapper.Map<List<SliderGetDto>>(properties);
		}
		public async Task<List<SliderGetDto>> GetOnlyApproved()
		{
			List<Property> properties = await _propertyRepository.GetAllAsync(p => !p.IsDeleted && p.Status == "Approved" && p.IsFeatured, "propertyAmenities", "Images");
			if (properties is null) throw new NotFoundException(Messages.PropertyNotFound);
			return _mapper.Map<List<SliderGetDto>>(properties);
		}

		public async Task DeleteSlider(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id, "propertyAmenities", "Images");
			property.IsFeatured= false;
			await _context.SaveChangesAsync();
			
		}


		public async Task MakeSlider(int Id)
		{
			Property property = await _propertyRepository.GetAsync(p => p.Id == Id, "propertyAmenities", "Images");
			property.IsFeatured= true;
			await _context.SaveChangesAsync();
		}


	}
}
