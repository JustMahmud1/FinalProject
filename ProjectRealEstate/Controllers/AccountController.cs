using Entities.Concrete;
using Entities.DTOs.AppUserDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectRealEstate.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;
		private readonly UserManager<AppUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;

		public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_roleManager = roleManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Register(UserRegisterDto registerDto)
		{
			if (!ModelState.IsValid)
			{
				ModelState.AddModelError("", "Fields can't be null");
				return View(registerDto);
			}

			AppUser appUser = new AppUser()
			{
				FullName = registerDto.FullName,
				UserName = registerDto.Username,
				Email = registerDto.Email,
				PhoneNumber=registerDto.PhoneNumber
			};

			IdentityResult result = await _userManager.CreateAsync(appUser, registerDto.Password);

			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
					return View();
				}
			}

			await _userManager.AddToRoleAsync(appUser, "User");

			return RedirectToAction("Index", "Home");
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(UserLoginDto loginDto)
		{
			if (string.IsNullOrWhiteSpace(loginDto.Username) || string.IsNullOrWhiteSpace(loginDto.Password))
			{
				ModelState.AddModelError("", "Fields can't be null");
				return View(loginDto);
			}
			AppUser appUser = await _userManager.FindByNameAsync(loginDto.Username);
			if (appUser == null)
			{
				ModelState.AddModelError("", "Username or Password is incorrect");
				return View();
			}

			Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginDto.Password, true, true);

			if (!result.Succeeded)
			{
				if (result.IsLockedOut)
				{
					ModelState.AddModelError("", "Your account is temporarily banned (Password was typed incorrectly 5 times)");
					return View();
				}

				ModelState.AddModelError("", "Username or Password is incorrect");
				return View();
			}
			if (await _userManager.IsInRoleAsync(appUser, "Admin"))
			{
				return RedirectToAction("Dashboard", "Admin");
			}

			return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}

		[Authorize]
		public async Task<IActionResult> Profile()
		{
			return View();
		}

		//public async Task<IActionResult> CreateRole()
		//{
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
		//	await _roleManager.CreateAsync(new IdentityRole { Name = "Agent" });
		//	return Json("Ok");
		//}
	}
}
