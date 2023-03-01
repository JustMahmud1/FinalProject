using Entities.Concrete;

namespace Entities.DTOs.SliderDTOs
{
	public class SliderGetDto
	{
		public SliderGetDto()
		{
			Images = new List<PropertyImage>();
		}
		public int Id { get; set; }
		public string Title { get; set; }
		public string Location { get; set; }
		public double Price { get; set; }
		public List<PropertyImage> Images { get; set; }
	}
}
