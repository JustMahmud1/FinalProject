using Entities.DTOs.SliderDTOs;

namespace Business.Services.Abstract
{
	public interface ISliderService
	{
		Task<List<SliderGetDto>> GetAllAsync();
		Task<List<SliderGetDto>> GetOnlyApproved();
		Task MakeSlider(int Id);
		Task DeleteSlider(int Id);
	}
}
