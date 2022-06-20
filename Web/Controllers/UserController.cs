using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Models;
using Web.Services;

namespace Web.Controllers
{
	public class UserController : Controller
	{
		private UserService _userService;

		public UserController(UserService userService)
		{
			this._userService = userService;
		}

		[HttpGet]
		public IActionResult Login()
		{
			LoginViewModel model = new LoginViewModel();

			return View(model);
		}

		[HttpPost]
		public IActionResult Login(LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				try
				{
					string email = model.Email;
					string password = model.Password;
					this._userService.Login(email, password);
				}
				catch (Exception)
				{
					ModelState.AddModelError("loginError", "Невалидно потребителско име или парола");
					return View(model);
				}
			}
			else
			{
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Register()
		{
			RegisterViewModel model = new RegisterViewModel();

			return View(model);
		}

		[HttpPost]
		public IActionResult Register(RegisterViewModel model)
		{
			if (ModelState.IsValid)
			{
				if(model.Password != model.ConfirmPassword)
				{
					ModelState.AddModelError("PassError", "Passwords do not match");
					return View(model);
				}
				else
				{
					User user = new User
					{
						FirstName = model.FirstName,
						LastName = model.LastName,
						Email = model.Email,
						Password = model.Password,
						PhoneNumber = model.PhoneNumber,
						Role = DataAccess.Model.Enums.Role.Buyer
					};

					try
					{
						this._userService.Register(user);
					}
					catch
					{
						ModelState.AddModelError("UserError", "A user with the same email already exists");
						return View(model);
					}
				}
			}
			else
			{
				return View(model);
			}

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Cart()
		{
			return View();
		}
	}
}