using Entities.Abstract;

namespace Entities.Concrete
{
	public class About : IEntity
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Image1 { get; set; }
		public string ImageDescription { get; set; }
		public string ImageSubDescription { get; set; }
		public string Image2 { get; set; }
		public string DescriptionHeader { get; set; }
		public string Description { get; set; }
	}
}
