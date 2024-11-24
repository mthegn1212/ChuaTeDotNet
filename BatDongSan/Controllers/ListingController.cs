using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;
using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BatDongSan.Controllers
{
	public class ListingController : Controller
	{
		private readonly MenuService _menuService;
		private readonly ProjectService _projectService;
		private readonly NewsService _newService;
		private readonly MyDbContext _context;

		public ListingController(MenuService menuService, ProjectService projectService, NewsService newService, MyDbContext context)
		{
			_menuService = menuService;
			_projectService = projectService;
			_newService = newService;
			_context = context;
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
			if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserName")))
			{
				TempData["ErrorMessage"] = "Bạn cần đăng nhập để truy cập trang này.";
				return RedirectToAction("Login", "SignIn");
			}

			// Truyền đối tượng rỗng cho view
			var model = new News();

			if (TempData["MenuItems"] != null)
			{
				var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuItem>>(TempData["MenuItems"].ToString());
				ViewBag.MenuItems = menuItems;
			}
			else
			{
				var menuItems = _menuService.GetMenuItems();
				ViewBag.MenuItems = menuItems;
			}

			var salePro = _projectService.GetSalePro();
			ViewBag.SalePro = salePro;
			var news = _newService.GetTop4();
			ViewBag.News = news;

			return View("PostNew", model); // Truyền model vào view
		}

		public IActionResult Preview()
		{
			if (TempData["MenuItems"] != null)
			{
				var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuItem>>(TempData["MenuItems"].ToString());
				ViewBag.MenuItems = menuItems;
			}
			else
			{
				var menuItems = _menuService.GetMenuItems();
				ViewBag.MenuItems = menuItems;
			}
			return View("Preview");
		}
	}
}
