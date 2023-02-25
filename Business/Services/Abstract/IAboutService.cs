using Entities.DTOs.AboutDTOs;
using Entities.DTOs.AmenityDTOs;
using Entities.DTOs.SettingDTOs;

namespace Business.Services.Abstract
{
	public interface IAboutService
	{
		Task<AboutGetDto> Get();
		Task UpdateAsync(AboutUpdateDto aboutUpdateDto);
		Task CreateAsync(AboutPostDto aboutPostDto);
	}
}
