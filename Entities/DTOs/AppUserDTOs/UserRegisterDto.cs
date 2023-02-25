using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Entities.DTOs.AppUserDTOs
{
	public class UserRegisterDto
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Username { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		[Phone]
		public string PhoneNumber { get; set; }
		[Required]
		[PasswordPropertyText]
		public string Password { get; set; }
		[Required]
		public string ConfirmPassword { get; set; }
	}
}
