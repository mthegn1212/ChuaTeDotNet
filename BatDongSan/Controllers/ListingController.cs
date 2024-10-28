using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;
using BatDongSan.Models;

namespace BatDongSan.Controllers
{
	public class ListingController : Controller
	{
		private readonly MenuService _menuService;
		private readonly ProjectService _projectService;
		private readonly NewsService _newService;

		public ListingController(MenuService menuService, ProjectService projectService, NewsService newService)
		{
			_menuService = menuService;
			_projectService = projectService;
			_newService = newService;
		}

		public IActionResult Index()
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			var top5Pro = _projectService.GetTop5();
			ViewBag.Top5Pro = top5Pro;
			var rentPro = _projectService.GetRentPro();
			ViewBag.RentPro = rentPro;
			var salePro = _projectService.GetSalePro();
			ViewBag.SalePro = salePro;
			var projects = _projectService.GetAllProject();
			ViewBag.Projects = projects;

			return View("listing", top5Pro);
		}
		public ActionResult Details(int id)
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			var project = _projectService.find(id);
			ViewBag.ProjectById = project;
            var top5Pro = _projectService.GetTop5();
            ViewBag.Top5Pro = top5Pro;

            return View("Detail");
		}
		public IActionResult RentListing()
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			var rentPro = _projectService.GetRentPro();
			ViewBag.RentPro = rentPro;
			var news = _newService.GetTop4();
			ViewBag.News = news;

			return View("RentListing");
		}
		public IActionResult SaleListing()
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			var salePro = _projectService.GetSalePro();
			ViewBag.SalePro = salePro;
			var news = _newService.GetTop4();
			ViewBag.News = news;

			return View("SaleListing");
		}
		public IActionResult PostNew()
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			return View("Postnew");
		}
		public IActionResult Preview()
		{
			var menuItems = _menuService.GetMenuItems();
			ViewBag.MenuItems = menuItems;
			return View("Preview");
		}
	}
}
