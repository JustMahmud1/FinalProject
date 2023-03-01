using Entities.DTOs.PropertyDTOs;
using Entities.DTOs.SliderDTOs;

namespace ProjectRealEstate.ViewModels
{
	public class HomeVM
	{
		public List<PropertyGetDto> propertyGetDtos { get; set; }
		public List<SliderGetDto> sliderGetDtos { get; set; }
	}
}
