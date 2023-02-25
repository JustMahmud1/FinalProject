using Business.Services.Abstract;
using Entities.DTOs.SettingDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class SettingController : Controller
	{
		private readonly ISettingService _settingService;

		public SettingController(ISettingService settingService)
		{
			_settingService = settingService;
		}

		public async Task<IActionResult> Index()
		
		{
			SettingGetDto settingGetDto = await _settingService.Get();
			return View(settingGetDto);
		}

		public async Task<IActionResult> Update()
		{
			SettingUpdateDto settingUpdateDto = new SettingUpdateDto();
			settingUpdateDto.settingGetDto = await _settingService.Get();
			return View(settingUpdateDto);
		}

		[HttpPost]
		public async Task<IActionResult> Update(SettingUpdateDto settingUpdateDto)
		{
			settingUpdateDto.settingGetDto = await _settingService.Get();
			await _settingService.UpdateAsync(settingUpdateDto);
			return RedirectToAction(nameof(Index));

		}
	}
}
