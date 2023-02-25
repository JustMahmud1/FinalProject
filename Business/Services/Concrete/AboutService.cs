using AutoMapper;
using Business.Services.Abstract;
using Business.Utilities.Extensions;
using DataAccess.Repositories.Abstract;
using Entities.Concrete;
using Entities.DTOs.AboutDTOs;
using Microsoft.AspNetCore.Hosting;

namespace Business.Services.Concrete
{
	public class AboutService : IAboutService	
	{
		private readonly IAboutRepository _aboutRepository;
		private readonly IMapper _mapper;
		private readonly IWebHostEnvironment _env;

		public AboutService(IAboutRepository aboutRepository, IMapper mapper, IWebHostEnvironment env)
		{
			_aboutRepository = aboutRepository;
			_mapper = mapper;
			_env = env;
		}
		public async Task<AboutGetDto> Get()
		{
			About about = await _aboutRepository.Get();
			AboutGetDto aboutGetDto = _mapper.Map<AboutGetDto>(about);
			return aboutGetDto;

		}

		public async Task CreateAsync(AboutPostDto aboutPostDto)
		{
			About about = _mapper.Map<About>(aboutPostDto);
			about.Image1 = aboutPostDto.Image1.CreateFile(_env.WebRootPath, "assets/img");
			about.Image2 = aboutPostDto.Image2.CreateFile(_env.WebRootPath, "assets/img");
			await _aboutRepository.CreateAsync(about);
		}


		public async Task UpdateAsync(AboutUpdateDto aboutUpdateDto)
		{
			About about = await _aboutRepository.GetAsync(f => f.Id == aboutUpdateDto.aboutGetDto.Id);
			aboutUpdateDto.aboutGetDto = _mapper.Map<AboutGetDto>(about);
			about.Title = aboutUpdateDto.aboutPostDto.Title;
			about.Description = aboutUpdateDto.aboutPostDto.Description;
			about.ImageDescription = aboutUpdateDto.aboutPostDto.ImageDescription;
			about.ImageSubDescription = aboutUpdateDto.aboutPostDto.ImageSubDescription;
			about.DescriptionHeader = aboutUpdateDto.aboutPostDto.DescriptionHeader;
			if(aboutUpdateDto.aboutPostDto.Image1!= null)
			{
				about.Image1 = aboutUpdateDto.aboutPostDto.Image1.CreateFile(_env.WebRootPath,"assets/img");
			}
			if (aboutUpdateDto.aboutPostDto.Image2 != null)
			{
				about.Image2 = aboutUpdateDto.aboutPostDto.Image2 .CreateFile(_env.WebRootPath, "assets/img");
			}
			_aboutRepository.UpdateAsync(about);
		}
	}
}
