using Microsoft.AspNetCore.Mvc;
using BatDongSan.Services;
using BatDongSan.Models;

namespace BatDongSan.Controllers
{
	public class ListingController : Controller
	{
		private readonly MenuService _menuService;
		private readonly ProjectService _projectService;

        public ListingController(MenuService menuService, ProjectService projectService)
		{
			_menuService = menuService;
			_projectService = projectService;
            
        }
         
        public IActionResult Index()
		{
			var menuItems = _menuService.GetMenuItems(); // Lấy danh sách menu
			ViewBag.MenuItems = menuItems;

            var top5Pro = _projectService.GetTop5();
			ViewBag.Top5Pro = top5Pro;
			var rentPro = _projectService.GetRentPro();
			ViewBag.RentPro = rentPro;
			var salePro = _projectService.GetSalePro();
			ViewBag.SalePro = salePro;
			
			var projects = _projectService.GetAllProject();
			ViewBag.Projects = projects;
			// Truyền danh sách vào ViewBag

			return View("listing"); // Trả về view listing.cshtml
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
	}
}
