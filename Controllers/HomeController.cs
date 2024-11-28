using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using BatDongSan.Services;
using Microsoft.EntityFrameworkCore;

namespace BatDongSan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MenuService _menuService;
        private readonly ProjectService _projectService;
        private readonly NewsService _newService;

        public HomeController(ILogger<HomeController> logger, MenuService menuService, ProjectService projectService, NewsService newService)
        {
            _logger = logger;
            _menuService = menuService;
            _projectService = projectService;
            _newService = newService;
        }

        public IActionResult Index()
        {
            // Kiểm tra nếu MenuItems tồn tại trong TempData
            if (TempData["MenuItems"] != null)
            {
                var menuItems = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MenuItem>>(TempData["MenuItems"].ToString());
                ViewBag.MenuItems = menuItems;
            }
            else
            {
                // Nếu không có menu trong TempData, lấy từ dịch vụ
                var menuItems = _menuService.GetMenuItems();
                ViewBag.MenuItems = menuItems;
            }

            var Projects = _projectService.GetTop5();
            ViewBag.Top4Projects = Projects;

            var News = _newService.GetTop4();
            ViewBag.Top4News = News;
            return View();
        }
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
