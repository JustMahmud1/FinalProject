using Entities.DTOs.SettingDTOs;

namespace Business.Services.Abstract
{
	public interface ISettingService
	{
		Task<SettingGetDto> Get();
		Task UpdateAsync(SettingUpdateDto settingUpdateDto);
		Task CreateAsync(SettingPostDto settingPostDto);
	}
}
