using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;

namespace BatDongSan.Controllers
{
	public class AboutController : Controller
	{
		private readonly MenuService _menuService;

		public AboutController(MenuService menuService)
		{
			_menuService = menuService;
		}

		public IActionResult Index()
		{
			var menuItems = _menuService.GetMenuItems(); // Lấy danh sách menu
			ViewBag.MenuItems = menuItems; // Truyền danh sách vào ViewBag
			return View("about"); // Trả về view listing.cshtml
		}
	}
}
