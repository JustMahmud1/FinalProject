using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.AboutDTOs
{
	public class AboutPostDto
	{
		[Required]
		public string Title { get; set; }
		[Required]
		public IFormFile Image1 { get; set; }
		[Required]
		public string ImageDescription { get; set; }
		[Required]
		public string ImageSubDescription { get; set; }
		[Required]
		public IFormFile Image2 { get; set; }
		[Required]
		public string DescriptionHeader { get; set; }
		[Required]
		public string Description { get; set; }
	}
}
