using BatDongSan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Collections.Generic;
using BatDongSan.Services;

namespace BatDongSan.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MenuService _menuService;

        public HomeController(ILogger<HomeController> logger, MenuService menuService)
        {
            _logger = logger;
            _menuService = menuService;
        }

        public IActionResult Index()
        {
            var menuItems = _menuService.GetMenuItems(); // Lấy danh sách menu
            ViewBag.MenuItems = menuItems; // Truyền danh sách vào ViewBag
            return View(); // Trả về View mà không cần truyền model, vì menu đã có trong ViewBag
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
