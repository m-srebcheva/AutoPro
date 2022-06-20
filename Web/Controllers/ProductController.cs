using DataAccess.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Helpers;
using Web.Services;

namespace Web.Controllers
{
	public class ProductController : Controller
	{
		private ProductService _productService;

		public ProductController(ProductService productService)
		{
			this._productService = productService;
		}

		[HttpGet]
		[Route("/product/{id}")]
		public IActionResult Open([FromRoute] string id)
		{
			Service service = this._productService.GetService(id);
			return View(service);
		}

		[HttpGet]
		public IActionResult AddToCart([FromRoute] string id)
		{
			if (Logged.IsLogged())
			{
				Service service = this._productService.GetService(id);
				Logged.Cart.Add(service);
			}
			else
			{
				return RedirectToAction("Login", "User");
			}

			return RedirectToAction("Cart", "User");
		}


		[HttpGet]
		[Route("/product/remove/{id}")]
		public IActionResult Remove([FromRoute] string id)
		{
			if (Logged.IsLogged())
			{
				Logged.Cart.Remove(Logged.Cart.FirstOrDefault(x => x.Id.ToString() == id));
			}

			return RedirectToAction("Cart", "User");
		}
	}
}
