﻿using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs.AppUserDTOs
{
	public class UserLoginDto
	{
		[Required]
		public string Username { get; set; }
		[Required]
		public string Password { get; set; }
	}
}
