using AutoMapper;
using Business.Services.Abstract;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.SettingDTOs;

namespace Business.Services.Concrete
{
	public class SettingService : ISettingService
	{
		private readonly ISettingRepository _settingRepository;
		private readonly IMapper _mapper;

		public SettingService(ISettingRepository settingRepository, IMapper mapper)
		{
			_settingRepository = settingRepository;
			_mapper = mapper;
		}
		public async Task<SettingGetDto> Get()
		{
			Setting setting = await _settingRepository.Get();
			SettingGetDto settingGetDto = _mapper.Map<SettingGetDto>(setting);
			return settingGetDto;

		}

		public async Task CreateAsync(SettingPostDto settingPostDto)
		{
			Setting setting = _mapper.Map<Setting>(settingPostDto);
			await _settingRepository.CreateAsync(setting);
		}


		public async Task UpdateAsync(SettingUpdateDto settingUpdateDto)
		{
			Setting setting = await _settingRepository.GetAsync(f=>f.Id == settingUpdateDto.settingGetDto.Id);
			settingUpdateDto.settingGetDto = _mapper.Map<SettingGetDto>(setting);
			setting.Address = settingUpdateDto.settingPostDto.Address;
			setting.PhoneNumber = settingUpdateDto.settingPostDto.PhoneNumber;
			setting.Email = settingUpdateDto.settingPostDto.Email;
			setting.InstagramUrl = settingUpdateDto.settingPostDto.InstagramUrl;
			setting.FacebookUrl = settingUpdateDto.settingPostDto.FacebookUrl;
			setting.TwitterUrl = settingUpdateDto.settingPostDto.TwitterUrl;
			_settingRepository.UpdateAsync(setting);
		}
	}
}
