using Entities.Concrete;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.SettingDTOs;
using System.Linq.Expressions;

namespace Business.Services.Abstract
{
	public interface IAmenityService
	{
		Task<List<AmenityGetDto>> GetAllAsync();
		//Task<List<AmenityGetDto>> GetAllAsync(Expression<Func<Amenity, bool>> expression = null, params string[] includes);
		Task<AmenityGetDto> GetByIdAsync(int Id);
		Task UpdateAsync(AmenityUpdateDto amenityUpdateDto);
		Task CreateAsync(AmenityPostDto amenityPostDto);
		Task DeleteAsync(int Id);
	}
}
