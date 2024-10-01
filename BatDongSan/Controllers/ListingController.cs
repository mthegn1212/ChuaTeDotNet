using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;

namespace BatDongSan.Controllers
{
	public class ListingController : Controller
	{
		private readonly MenuService _menuService;

		public ListingController(MenuService menuService)
		{
			_menuService = menuService;
		}

		public IActionResult Index()
		{
			var menuItems = _menuService.GetMenuItems(); // Lấy danh sách menu
			ViewBag.MenuItems = menuItems; // Truyền danh sách vào ViewBag
			return View("listing"); // Trả về view listing.cshtml
		}
	}
}
